using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniSavari.Application.DTOs
{
    public class SeatLayoutRequestDto
    {
        public long TripId { get; set; }
        public long FromStopId { get; set; }
        public long ToStopId { get; set; }
    }
}
