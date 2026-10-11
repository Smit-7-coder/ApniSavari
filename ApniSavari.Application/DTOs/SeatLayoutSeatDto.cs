using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniSavari.Application.DTOs
{
    public class SeatLayoutSeatDto
    {
        public long TripSeatInventoryId { get; set; }

        public long SeatLayoutSeatId { get; set; }

        public string SeatCode { get; set; } = string.Empty;

        public string SeatType { get; set; } = string.Empty;

        public string Deck { get; set; } = string.Empty;

        public short? RowNumber { get; set; }

        public short? ColumnNumber { get; set; }

        public int? PositionFlags { get; set; }

        public bool IsBookable { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal? Fare { get; set; }

        public string Currency { get; set; } = "INR";
    }
}
