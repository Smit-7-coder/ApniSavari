using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniSavari.Application.DTOs
{
    public class StopSearchResponseDto
    {
        public long StopId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? City { get; set; }

        public string? StateCode { get; set; }
    }
}
