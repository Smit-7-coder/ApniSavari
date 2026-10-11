using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApniSavari.Application.DTOs;

namespace ApniSavari.Application.Interfaces
{
    public interface ISeatLayoutService
    {
        Task<SeatLayoutResponseDto?> GetSeatLayoutAsync(
            long tripId,
            long fromStopId,
            long toStopId,
            CancellationToken cancellationToken = default);
    }
}
