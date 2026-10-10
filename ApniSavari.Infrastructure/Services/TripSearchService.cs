using ApniSavari.Application.DTOs;
using ApniSavari.Application.Interfaces;
using ApniSavari.Infrastructure.Persistence.Context.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniSavari.Infrastructure.Services
{
    public class TripSearchService : ITripSearchService
    {
        private readonly ApniSavariDbContext _context;
        public TripSearchService(ApniSavariDbContext context)
        {
            _context = context;
        }

        public async Task<List<TripSearchResponseDto>> SearchTripsAsync(
           long fromStopId,
            long toStopId,
            DateOnly date)
        {
            if (fromStopId == toStopId)
            {
                return new List<TripSearchResponseDto>();
            }

            var trips = await _context.Trips
                .AsNoTracking()
                .Where(t =>
                t.ServiceDate == date &&
                t.Status == "Active")
                .Include(t => t.TripStops)
                    .ThenInclude(ts => ts.RouteStop)
                    .ThenInclude(rs => rs.Stop)
                .Include(t => t.TripBuses)
                    .ThenInclude(tb => tb.Bus)
                    .ThenInclude(b => b.BusType)
                .Include(t => t.TripFares)
                .Include(t => t.TripSeatInventories)
                .ToListAsync();

                var operatorIds = trips
                    .Select(t => t.OperatorId)
                    .Distinct()
                    .ToList();

                var operatorNames = await _context.Operators
                    .AsNoTracking()
                    .Where(o => operatorIds.Contains(o.OperatorId))
                    .ToDictionaryAsync(
                        o => o.OperatorId,
                        o => o.DisplayName
                    );

            var results = new List<TripSearchResponseDto>();
            foreach (var trip in trips)
            {
                var boardingTripStop = trip.TripStops
                    .FirstOrDefault(ts =>
                    ts.RouteStop.StopId == fromStopId);

                var droppingTripStop = trip.TripStops
                .FirstOrDefault(ts =>
                    ts.RouteStop.StopId == toStopId);

                if (boardingTripStop == null || droppingTripStop == null)
                {
                    continue;
                }

                if (boardingTripStop.SequenceNo == null ||
                droppingTripStop.SequenceNo == null)
                {
                    continue;
                }

                if (boardingTripStop.SequenceNo >= droppingTripStop.SequenceNo)
                {
                    continue;
                }

                var tripBus = trip.TripBuses
                .FirstOrDefault(tb =>
                    tb.IsPrimary == true &&
                    tb.Status == "Active");

                if (tripBus?.Bus == null)
                {
                    continue;
                }

                var fare = trip.TripFares
                .FirstOrDefault(f =>
                    f.FromTripStopId == boardingTripStop.TripStopId &&
                    f.ToTripStopId == droppingTripStop.TripStopId);

                if (fare == null)
                {
                    continue;
                }

                var availableSeats = trip.TripSeatInventories
                    .Count(s => s.Status == "Available");

                results.Add(new TripSearchResponseDto
                {
                    TripId = trip.TripId,
                    TripCode = trip.TripCode,

                    Bus = new BusSearchInfoDto
                    {
                        BusType = tripBus.Bus.BusType.Name,

                        RegistrationNumber =
                            tripBus.RegistrationNumberSnapshot
                            ?? tripBus.Bus.RegistrationNumber,

                        OperatorDisplayName =
                        operatorNames.TryGetValue(trip.OperatorId, out var displayName)
                        ? displayName
                        : "Bus operator"
                    },

                    Boarding = new TripStopInfoDto
                    {
                        StopId = boardingTripStop.RouteStop.StopId,
                        StopName = boardingTripStop.RouteStop.Stop.Name,
                        Time = boardingTripStop.DepartureAtLocal
                    },

                    Dropping = new TripStopInfoDto
                    {
                        StopId = droppingTripStop.RouteStop.StopId,
                        StopName = droppingTripStop.RouteStop.Stop.Name,
                        Time = droppingTripStop.ArrivalAtLocal
                    },

                    Fare = new TripFareInfoDto
                    {
                        SeatType = fare.SeatType,
                        BaseFare = fare.BaseFare ?? 0,
                        TaxAmount = fare.TaxAmount ?? 0,
                        TotalFare = fare.TotalFare ?? 0,
                        Currency = fare.CurrencyCode
                    },

                    AvailableSeats = availableSeats
                });
            }

            return results;
        }
    }
}
