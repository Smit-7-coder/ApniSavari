import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { StopService } from '../../../core/services/stop.service';
import { Stop } from '../../../core/models/stop.mode';

import{ TripService } from '../../../core/services/trip.service';
import { TripSearchResult } from '../../../core/models/trip-search';

import { Router } from '@angular/router';
@Component({
  imports: [FormsModule],
  selector: 'app-home',
  styleUrl: './home.css',
  templateUrl: './home.html',
})
export class Home {
    private readonly stopService = inject(StopService);
   private readonly tripService = inject(TripService);
   private readonly router = inject(Router);
   trips: TripSearchResult[] = [];
isLoading = false;
searchError = '';
    fromQuery = '';
    toQuery = '';

    fromStops: Stop[] = [];
    toStops: Stop[] = [];

    selectedFromStop: Stop | null = null;
    selectedToStop: Stop | null = null;

    journeyDate = '';

    searchFromStops(): void{
      this.selectedFromStop = null;

      if(this.fromQuery.trim().length<2){
        this.fromStops = [];
        return;
      }
      this.stopService
      .searchStops(this.fromQuery)
      .subscribe({
        next: (stops) => {
          this.fromStops = stops;
        },
        error:(error)=>{
          console.error('Failed to search FROM stops', error);
          this.fromStops = [];
        }
      });
    }

    searchToStops(): void{
      this.selectedToStop = null;

      if(this.toQuery.trim().length<2){
        this.toStops = [];
        return;
      }

      this.stopService
      .searchStops(this.toQuery)
      .subscribe({
        next: (stops) => {
          this.toStops = stops;
        },
        error:(error)=>{
          console.error('Failed to search TO stops', error);
          this.toStops = [];
        }
      });
    }

    selectFromStop(stop: Stop): void {
    this.selectedFromStop = stop;
    this.fromQuery = stop.name;
    this.fromStops = [];
  }

  selectToStop(stop: Stop): void {
    this.selectedToStop = stop;
    this.toQuery = stop.name;
    this.toStops = [];
  }

  swapStops(): void {

    const oldFromQuery = this.fromQuery;
    const oldFromStop = this.selectedFromStop;

    this.fromQuery = this.toQuery;
    this.selectedFromStop = this.selectedToStop;

    this.toQuery = oldFromQuery;
    this.selectedToStop = oldFromStop;
  }

  
searchBuses(): void {
  if (!this.selectedFromStop || !this.selectedToStop) {
    alert('Please select both FROM and TO locations.');
    return;
  }

  if (this.selectedFromStop.stopId === this.selectedToStop.stopId) {
    alert('FROM and TO locations must be different.');
    return;
  }

  if (!this.journeyDate) {
    alert('Please select a journey date.');
    return;
  }

  this.router.navigate(['/customer_guest/search-results'], {
    queryParams: {
      fromStopId: this.selectedFromStop.stopId,
      toStopId: this.selectedToStop.stopId,
      fromName: this.selectedFromStop.name,
      toName: this.selectedToStop.name,
      date: this.journeyDate
    }
  });
}
}