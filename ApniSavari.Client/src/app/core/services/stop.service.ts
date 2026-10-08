import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Stop } from '../models/stop.mode';
@Injectable({
    providedIn: 'root'
})
export class StopService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'https://localhost:7274/api/stops';

  searchStops(query:string):Observable<Stop[]>{
    const params = new HttpParams()
    .set('query', query);

    return this.http.get<Stop[]>(
        `${this.apiUrl}/search`,
        { params }
    );
  }
}
