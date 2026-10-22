
import {
  ChangeDetectorRef,
  Component,
  DestroyRef,
  OnInit,
  inject
} from '@angular/core';

import { CurrencyPipe, DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { finalize } from 'rxjs';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

import { TripService } from '../../core/services/trip.service';

import {
  SeatLayoutResponse,
  SeatLayoutSeat
} from '../../core/models/seat-layout.model';

@Component({
  selector: 'app-seat-selection',
  standalone: true,
  imports: [DatePipe, CurrencyPipe],
  templateUrl: './seat-selection.html',
  styleUrl: './seat-selection.css'
})
export class SeatSelection implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly tripService = inject(TripService);
  private readonly destroyRef = inject(DestroyRef);
  private readonly cdr = inject(ChangeDetectorRef);

  layout: SeatLayoutResponse | null = null;

  loading = false;
  error = '';

  fromStopId = 0;
  toStopId = 0;
  tripId = 0;

  activeDeck = 'Lower';
  selectedSeatIds = new Set<number>();

  ngOnInit(): void {
    this.route.queryParamMap
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe(params => {
        this.tripId = Number(params.get('tripId'));
        this.fromStopId = Number(params.get('fromStopId'));
        this.toStopId = Number(params.get('toStopId'));

        if (
          !Number.isInteger(this.tripId) ||
          this.tripId <= 0 ||
          !Number.isInteger(this.fromStopId) ||
          this.fromStopId <= 0 ||
          !Number.isInteger(this.toStopId) ||
          this.toStopId <= 0 ||
          this.fromStopId === this.toStopId
        ) {
          this.loading = false;
          this.layout = null;
          this.error =
            'Invalid journey details. Please search again.';

          this.cdr.detectChanges();
          return;
        }

        this.loadSeatLayout();
      });
  }

  loadSeatLayout(): void {
    if (
      this.tripId <= 0 ||
      this.fromStopId <= 0 ||
      this.toStopId <= 0 ||
      this.fromStopId === this.toStopId
    ) {
      this.loading = false;
      this.layout = null;
      this.error = 'Invalid journey details. Please search again.';
      this.cdr.detectChanges();
      return;
    }

    this.loading = true;
    this.error = '';
    this.layout = null;
    this.selectedSeatIds = new Set<number>();

    this.cdr.detectChanges();

    this.tripService
      .getSeatLayout(
        this.tripId,
        this.fromStopId,
        this.toStopId
      )
      .pipe(
        takeUntilDestroyed(this.destroyRef),
        finalize(() => {
          this.loading = false;
          this.cdr.detectChanges();
        })
      )
      .subscribe({
        next: (response: SeatLayoutResponse) => {
          console.log('Seat layout API response:', response);

          if (!response || !Array.isArray(response.seats)) {
            this.layout = null;
            this.error =
              'The API response does not contain a valid seats array.';

            this.loading = false;
            this.cdr.detectChanges();
            return;
          }

          this.layout = response;
          this.error = '';
          this.loading = false;
          this.selectedSeatIds = new Set<number>();

          if (response.seats.length === 0) {
            this.error = 'No seats were returned for this trip.';
          }

          console.log('Loading:', this.loading);
          console.log('Total berths:', response.seats.length);

          this.cdr.detectChanges();
        },

        error: err => {
          console.error('Failed to load seat layout:', err);

          this.layout = null;
          this.loading = false;
          this.error =
            'Unable to load the seat layout. Please try again.';

          this.cdr.detectChanges();
        },

        complete: () => {
          this.loading = false;
          this.cdr.detectChanges();
        }
      });
  }

  // Lower berth data for the two-panel layout.
  get lowerSeats(): SeatLayoutSeat[] {
    return this.getDeckSeats('Lower');
  }

  // Upper berth data for the two-panel layout.
  get upperSeats(): SeatLayoutSeat[] {
    return this.getDeckSeats('Upper');
  }

  private getDeckSeats(deckName: string): SeatLayoutSeat[] {
    return (this.layout?.seats ?? [])
      .filter(seat =>
        (seat.deck ?? '')
          .toLowerCase()
          .includes(deckName.toLowerCase())
      )
      .slice()
      .sort((a, b) =>
        (a.rowNumber ?? 0) - (b.rowNumber ?? 0) ||
        (a.columnNumber ?? 0) - (b.columnNumber ?? 0)
      );
  }

  get selectedSeats(): SeatLayoutSeat[] {
    return (this.layout?.seats ?? []).filter(seat =>
      this.selectedSeatIds.has(seat.tripSeatInventoryId)
    );
  }

  get selectedSeatCodes(): string {
    return this.selectedSeats
      .map(seat => seat.seatCode)
      .join(', ');
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
    return (
      seat.isBookable === true &&
      seat.status?.toLowerCase() === 'available' &&
      seat.fare != null
    );
  }

  toggleSeat(seat: SeatLayoutSeat): void {
    if (!this.isAvailable(seat)) {
      return;
    }

    const updated = new Set(this.selectedSeatIds);
    const seatId = seat.tripSeatInventoryId;

    if (updated.has(seatId)) {
      updated.delete(seatId);
    } else {
      updated.add(seatId);
    }

    this.selectedSeatIds = updated;
    this.cdr.detectChanges();
  }

  continueBooking(): void {
    if (this.selectedSeats.length === 0) {
      return;
    }

    alert(
      'Seat selection is ready. The booking and seat-hold API is not connected yet.'
    );
  }

  goBack(): void {
    this.router.navigate(
      ['/customer_guest/search-results'],
      {
        queryParams: {
          fromStopId: this.fromStopId,
          toStopId: this.toStopId,
          fromName:
            this.route.snapshot.queryParamMap.get('fromName') ?? '',
          toName:
            this.route.snapshot.queryParamMap.get('toName') ?? '',
          date:
            this.route.snapshot.queryParamMap.get('date') ?? ''
        }
      }
    );
  }
}
