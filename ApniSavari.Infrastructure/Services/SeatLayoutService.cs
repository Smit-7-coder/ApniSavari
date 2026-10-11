
using ApniSavari.Application.DTOs;
using ApniSavari.Application.Interfaces;
using ApniSavari.Infrastructure.Persistence.Context.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApniSavari.Infrastructure.Services
{
    public class SeatLayoutService : ISeatLayoutService
    {
        private readonly ApniSavariDbContext _context;

        public SeatLayoutService(ApniSavariDbContext context)
        {
            _context = context;
        }

        public async Task<SeatLayoutResponseDto?> GetSeatLayoutAsync(
            long tripId,
            long fromStopId,
            long toStopId,
            CancellationToken cancellationToken = default)
        {
            if (tripId <= 0 ||
                fromStopId <= 0 ||
                toStopId <= 0 ||
                fromStopId == toStopId)
            {
                return null;
            }

            var trip = await _context.Trips
                .AsNoTracking()
                .Include(t => t.Operator)
                .Include(t => t.TripStops)
                    .ThenInclude(ts => ts.RouteStop)
                        .ThenInclude(rs => rs.Stop)
                .Include(t => t.TripBuses)
                    .ThenInclude(tb => tb.Bus)
                        .ThenInclude(b => b.BusType)
                .Include(t => t.TripSeatInventories)
                    .ThenInclude(i => i.SeatLayoutSeat)
                        .ThenInclude(s => s.SeatLayout)
                .Include(t => t.TripFares)
                .FirstOrDefaultAsync(
                    t => t.TripId == tripId && t.Status == "Active",
                    cancellationToken);

            if (trip == null)
            {
                return null;
            }

            // Find the boarding and dropping stops for this trip.
            var boarding = trip.TripStops.FirstOrDefault(ts =>
                ts.RouteStop != null &&
                ts.RouteStop.StopId == fromStopId);

            var dropping = trip.TripStops.FirstOrDefault(ts =>
                ts.RouteStop != null &&
                ts.RouteStop.StopId == toStopId);

            if (boarding == null ||
                dropping == null ||
                boarding.SequenceNo == null ||
                dropping.SequenceNo == null ||
                boarding.SequenceNo >= dropping.SequenceNo)
            {
                return null;
            }

            // Find the active primary bus assigned to this trip.
            var tripBus = trip.TripBuses.FirstOrDefault(tb =>
                tb.IsPrimary == true &&
                tb.Status == "Active" &&
                tb.Bus != null);

            if (tripBus?.Bus == null)
            {
                return null;
            }

            // Get inventory entries belonging to this bus's seat layout.
            var inventory = trip.TripSeatInventories
                .Where(i => i.SeatLayoutSeat != null)
                .Where(i =>
                    i.SeatLayoutSeat.SeatLayoutId ==
                    tripBus.Bus.SeatLayoutId)
                .ToList();

            if (inventory.Count == 0)
            {
                return null;
            }

            // Find fares for the selected journey segment.
            var fares = trip.TripFares
                .Where(f =>
                    f.FromTripStopId == boarding.TripStopId &&
                    f.ToTripStopId == dropping.TripStopId)
                .ToList();

            // Build the seat response.
            var seats = inventory
                .OrderBy(i => i.DeckSnapshot)
                .ThenBy(i => i.SeatLayoutSeat.RowNumber)
                .ThenBy(i => i.SeatLayoutSeat.ColumnNumber)
                .ThenBy(i => i.SeatCodeSnapshot)
                .Select(i =>
                {
                    var layoutSeat = i.SeatLayoutSeat!;

                    var seatType =
                        i.SeatTypeSnapshot ?? layoutSeat.SeatType;

                    var fare = fares.FirstOrDefault(f =>
                        string.Equals(
                            f.SeatType,
                            seatType,
                            StringComparison.OrdinalIgnoreCase));

                    var isBookable = layoutSeat.IsBookable == true;

                    var status = !isBookable
                        ? "NotBookable"
                        : i.Status ?? "Unavailable";

                    return new SeatLayoutSeatDto
                    {
                        TripSeatInventoryId = i.TripSeatInventoryId,
                        SeatLayoutSeatId = layoutSeat.SeatLayoutSeatId,

                        SeatCode =
                            i.SeatCodeSnapshot ?? layoutSeat.SeatCode,

                        SeatType = seatType,

                        Deck =
                            i.DeckSnapshot ?? layoutSeat.Deck,

                        RowNumber = layoutSeat.RowNumber,
                        ColumnNumber = layoutSeat.ColumnNumber,
                        PositionFlags = layoutSeat.PositionFlags,

                        IsBookable = isBookable,
                        Status = status,

                        Fare = fare?.TotalFare,
                        Currency = fare?.CurrencyCode ?? "INR"
                    };
                })
                .ToList();

            // Return the complete seat layout response.
            return new SeatLayoutResponseDto
            {
                TripId = trip.TripId,
                TripCode = trip.TripCode ?? string.Empty,

                OperatorDisplayName =
                    trip.Operator?.DisplayName ?? string.Empty,

                BusType =
                    tripBus.Bus.BusType?.Name ?? string.Empty,

                BoardingPoint = new SeatLayoutStopDto
                {
                    StopId = boarding.RouteStop.StopId,
                    TripStopId = boarding.TripStopId,

                    StopName =
                        boarding.RouteStop.Stop?.Name ?? string.Empty,

                    Time = boarding.DepartureAtLocal
                },

                DroppingPoint = new SeatLayoutStopDto
                {
                    StopId = dropping.RouteStop.StopId,
                    TripStopId = dropping.TripStopId,

                    StopName =
                        dropping.RouteStop.Stop?.Name ?? string.Empty,

                    Time = dropping.ArrivalAtLocal
                },

                Seats = seats
            };
        }
    }
}
