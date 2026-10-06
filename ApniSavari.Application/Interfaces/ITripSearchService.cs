using ApniSavari.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniSavari.Application.Interfaces
{
    public interface ITripSearchService
    {
        Task<List<TripSearchResponseDto>> SearchTripsAsync(
        long fromStopId,
        long toStopId,
        DateOnly date);
    }
}
