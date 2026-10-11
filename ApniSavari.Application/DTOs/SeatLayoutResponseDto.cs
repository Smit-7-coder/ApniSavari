using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniSavari.Application.DTOs
{
    public class SeatLayoutResponseDto
    {
        public long TripId { get; set; }

        public string TripCode { get; set; } = string.Empty;

        public string OperatorDisplayName { get; set; } = string.Empty;

        public string BusType { get; set; } = string.Empty;

        public SeatLayoutStopDto BoardingPoint { get; set; } = new();

        public SeatLayoutStopDto DroppingPoint { get; set; } = new();

        public List<SeatLayoutSeatDto> Seats { get; set; } = new();
    }
}
