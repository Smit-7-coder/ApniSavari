
import { DatePipe, DecimalPipe } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TripService } from '../../core/services/trip.service';
import {
  SeatLayoutResponse,
  SeatLayoutSeat
} from '../../core/models/seat-layout.model';

@Component({
  selector: 'app-seat-selection',
  standalone: true,
  imports: [DatePipe, DecimalPipe],
  templateUrl: './seat-selection.html',
  styleUrl: './seat-selection.css'
})
export class SeatSelection implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly tripService = inject(TripService);

  layout: SeatLayoutResponse | null = null;
  loading = false;
  error = '';

  fromStopId = 0;
  toStopId = 0;

  activeDeck = 'Lower';
  selectedSeatIds = new Set<number>();

 
ngOnInit(): void {
  const params = this.route.snapshot.queryParamMap;

  const tripId = Number(params.get('tripId'));
  this.fromStopId = Number(params.get('fromStopId'));
  this.toStopId = Number(params.get('toStopId'));

  if (
    !Number.isInteger(tripId) || tripId <= 0 ||
    !Number.isInteger(this.fromStopId) || this.fromStopId <= 0 ||
    !Number.isInteger(this.toStopId) || this.toStopId <= 0 ||
    this.fromStopId === this.toStopId
  ) {
    this.error = 'Journey details are invalid. Please search again.';
    this.loading = false;
    return;
  }

  this.loading = true;
  this.error = '';

  this.tripService
    .getSeatLayout(tripId, this.fromStopId, this.toStopId)
    .subscribe({
      next: response => {
        console.log('Seat layout API response:', response);

        this.layout = response;
        this.loading = false;
      },
      error: err => {
        console.error('Failed to load seat layout:', err);

        this.error = 'Unable to load the seat layout. Please try again.';
        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      }
    });
}

  get visibleSeats(): SeatLayoutSeat[] {
    return (this.layout?.seats ?? [])
      .filter(seat =>
        seat.deck?.toLowerCase() === this.activeDeck.toLowerCase()
      )
      .sort((a, b) =>
        (a.rowNumber ?? 0) - (b.rowNumber ?? 0) ||
        (a.columnNumber ?? 0) - (b.columnNumber ?? 0)
      );
  }

  get selectedSeats(): SeatLayoutSeat[] {
    return (this.layout?.seats ?? [])
      .filter(seat => this.selectedSeatIds.has(seat.tripSeatInventoryId));
  }

  get totalFare(): number {
    return this.selectedSeats.reduce(
      (total, seat) => total + (seat.fare ?? 0),
      0
    );
  }

  isSelected(seat: SeatLayoutSeat): boolean {
    return this.selectedSeatIds.has(seat.tripSeatInventoryId);
  }

  isAvailable(seat: SeatLayoutSeat): boolean {
    return seat.isBookable &&
      seat.status?.toLowerCase() === 'available' &&
      seat.fare !== null;
  }

  toggleSeat(seat: SeatLayoutSeat): void {
    if (!this.isAvailable(seat)) {
      return;
    }

    const id = seat.tripSeatInventoryId;
    const updated = new Set(this.selectedSeatIds);

    if (updated.has(id)) {
      updated.delete(id);
    } else {
      updated.add(id);
    }

    this.selectedSeatIds = updated;
  }

  continueBooking(): void {
    if (this.selectedSeats.length === 0) {
      return;
    }

    // Booking and seat-hold flow will be connected in the next step.
    alert('Seat selection is ready. Booking confirmation is not connected yet.');
  }

  goBack(): void {
    this.router.navigate(['/customer_guest/search-results'], {
      queryParams: {
        fromStopId: this.fromStopId,
        toStopId: this.toStopId,
        date: this.route.snapshot.queryParamMap.get('date') ?? ''
      }
    });
  }
}
