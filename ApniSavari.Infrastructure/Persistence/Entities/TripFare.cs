using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class TripFare
{
    public long TripFareId { get; set; }

    public long TripId { get; set; }

    public long FromTripStopId { get; set; }

    public long ToTripStopId { get; set; }

    public string? SeatType { get; set; }

    public decimal? BaseFare { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? TotalFare { get; set; }

    public string? CurrencyCode { get; set; }

    public virtual TripStop FromTripStop { get; set; } = null!;

    public virtual TripStop ToTripStop { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
