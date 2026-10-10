import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { TripSearchResult } from '../models/trip-search'; 
@Injectable({
    providedIn: 'root'
})
export class TripService {
private readonly http = inject(HttpClient);
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
            `${this.apiUrl}/search`, { params }
        );
    }
}
