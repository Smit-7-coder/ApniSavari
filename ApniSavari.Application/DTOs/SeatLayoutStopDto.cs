using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniSavari.Application.DTOs
{
    public class SeatLayoutStopDto
    {
        public long StopId { get; set; }

        public long TripStopId { get; set; }

        public string StopName { get; set; } = string.Empty;

        public DateTime? Time { get; set; }
    }
}
