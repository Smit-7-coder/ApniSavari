
import {
  ChangeDetectorRef,
  Component,
  DestroyRef,
  OnInit,
  inject
} from '@angular/core';
import { DatePipe, DecimalPipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

import { TripService } from '../../core/services/trip.service';
import { TripSearchResult } from '../../core/models/trip-search';

@Component({
  selector: 'app-search-results',
  standalone: true,
  imports: [DatePipe, DecimalPipe],
  templateUrl: './search-results.html',
  styleUrl: './search-results.css'
})
export class SearchResults implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly tripService = inject(TripService);
  private readonly destroyRef = inject(DestroyRef);
  private readonly cdr = inject(ChangeDetectorRef);

  trips: TripSearchResult[] = [];

  fromStopId = 0;
  toStopId = 0;
  boardingPointName = '';
  droppingPointName = '';
  journeyDate = '';

  isLoading = false;
  hasSearched = false;
  searchError = '';

  ngOnInit(): void {
    this.route.queryParamMap
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe(params => {
        this.fromStopId = Number(params.get('fromStopId'));
        this.toStopId = Number(params.get('toStopId'));
        this.boardingPointName = params.get('fromName') ?? '';
        this.droppingPointName = params.get('toName') ?? '';
        this.journeyDate = params.get('date') ?? '';

        if (
          !Number.isInteger(this.fromStopId) ||
          !Number.isInteger(this.toStopId) ||
          this.fromStopId <= 0 ||
          this.toStopId <= 0 ||
          this.fromStopId === this.toStopId ||
          !/^\d{4}-\d{2}-\d{2}$/.test(this.journeyDate)
        ) {
          this.trips = [];
          this.isLoading = false;
          this.hasSearched = true;
          this.searchError = 'Invalid journey details. Please search again.';
          return;
        }

        this.loadTrips();
      });
  }

  loadTrips(): void {
    this.isLoading = true;
    this.hasSearched = false;
    this.searchError = '';
    this.trips = [];

    this.tripService.searchTrips(
      this.fromStopId,
      this.toStopId,
      this.journeyDate
    )
    .pipe(takeUntilDestroyed(this.destroyRef))
    .subscribe({
      next: results => {
        this.trips = Array.isArray(results) ? results : [];
        this.isLoading = false;
        this.hasSearched = true;
        this.cdr.detectChanges();
      },
      error: error => {
        console.error('Failed to load bus results:', error);
        this.trips = [];
        this.isLoading = false;
        this.hasSearched = true;
        this.searchError = 'Unable to load buses. Please try again.';
        this.cdr.detectChanges();
      }
    });
  }

  searchAgain(): void {
    this.router.navigate(['/customer_guest/home']);
  }
}
