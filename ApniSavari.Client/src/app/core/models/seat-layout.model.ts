export interface SeatLayoutResponse {
  tripId: number;
  tripCode: string;
  operatorDisplayName: string;
  busType: string;
  boardingPoint: {
    stopId: number;
    tripStopId: number;
    stopName: string;
    time: string | null;
  };
  droppingPoint: {
    stopId: number;
    tripStopId: number;
    stopName: string;
    time: string | null;
  };
  seats: SeatLayoutSeat[];
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