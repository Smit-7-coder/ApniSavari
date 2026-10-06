using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniSavari.Application.DTOs
{
    public class TripSearchResponseDto
    {
        public long TripId { get; set; }
        public string TripCode { get; set; } = string.Empty;

        public BusSearchInfoDto Bus { get; set; } = new();

        public TripStopInfoDto Boarding { get; set; } = new();
        public TripStopInfoDto Dropping { get; set; } = new();

        public TripFareInfoDto Fare { get; set; } = new();

        public int AvailableSeats { get; set; }
    }
    public class BusSearchInfoDto
    {
        public string BusType { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
    }

    public class TripStopInfoDto
    {
        public long StopId { get; set; }
        public string StopName { get; set; } = string.Empty;
        public DateTime? Time { get; set; }
    }

    public class TripFareInfoDto
    {
        public string SeatType { get; set; } = string.Empty;
        public decimal BaseFare { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalFare { get; set; }
        public string Currency { get; set; } = string.Empty;
    }
}
