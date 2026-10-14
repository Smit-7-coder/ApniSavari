
import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { TripSearchResult } from '../models/trip-search';
import { SeatLayoutResponse } from '../models/seat-layout.model';

@Injectable({
  providedIn: 'root'
})
export class TripService {
  private readonly http = inject(HttpClient);

  // Used by the existing trip-search API.
  private readonly apiUrl = 'https://localhost:7274/api/trips';

  searchTrips(
    fromStopId: number,
    toStopId: number,
    date: string
  ): Observable<TripSearchResult[]> {
    const params = new HttpParams()
      .set('fromStopId', fromStopId.toString())
      .set('toStopId', toStopId.toString())
      .set('date', date);

    return this.http.get<TripSearchResult[]>(
      `${this.apiUrl}/search`,
      { params }
    );
  }

  getSeatLayout(
    tripId: number,
    fromStopId: number,
    toStopId: number
  ): Observable<SeatLayoutResponse> {
    const params = new HttpParams()
      .set('fromStopId', fromStopId.toString())
      .set('toStopId', toStopId.toString());

    // Seat layout uses SeatLayoutController, not TripsController.
    return this.http.get<SeatLayoutResponse>(
      `https://localhost:7274/api/SeatLayout/${tripId}/seat-layout`,
      { params }
    );
  }
}
