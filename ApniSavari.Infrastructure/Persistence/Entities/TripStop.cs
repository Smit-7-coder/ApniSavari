using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class TripStop
{
    public long TripStopId { get; set; }

    public long TripId { get; set; }

    public long RouteStopId { get; set; }

    public int? SequenceNo { get; set; }

    public DateTime? ArrivalAtLocal { get; set; }

    public DateTime? DepartureAtLocal { get; set; }

    public long? TimeZoneId { get; set; }

    public string? BoardingAllowed { get; set; }

    public string? DroppingAllowed { get; set; }

    public string Status { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;

    public virtual ICollection<TripFare> TripFareFromTripStops { get; set; } = new List<TripFare>();

    public virtual ICollection<TripFare> TripFareToTripStops { get; set; } = new List<TripFare>();
}
