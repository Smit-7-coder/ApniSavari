export interface TripSearchResult {
  tripId: number;
  tripCode: string;

  bus: {
    busType: string;
    registrationNumber: string;
    operatorDisplayName: string;
  };

  boarding: {
    stopId: number;
    stopName: string;
    time: string | null;
  };

  dropping: {
    stopId: number;
    stopName: string;
    time: string | null;
  };

  fare: {
    seatType: string;
    baseFare: number;
    taxAmount: number;
    totalFare: number;
    currency: string;
  };

  availableSeats: number;
}