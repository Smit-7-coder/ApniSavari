export interface SeatLayoutStop {
    stopId: number;
    tripStopId: number;
    stopName: string;
    time: string | null;
}

export interface SeatLayoutSeat {
    tripSeatInventoryId: number;
    seatLayoutSeatId: number;
    seatCode: string;
    seatType: string;
    deck: string;
    rowNumber: number | null;
    columnNumber: number | null;
    positionFlags: number | null;
    isBookable: boolean;
    status: string;
    fare: number | null;
    currency: string;
}

export interface SeatLayoutResponse {
  tripId: number;
  tripCode: string;
  operatorDisplayName: string;
  busType: string;
  boardingPoint: SeatLayoutStop;
  droppingPoint: SeatLayoutStop;
  seats: SeatLayoutSeat[];
}