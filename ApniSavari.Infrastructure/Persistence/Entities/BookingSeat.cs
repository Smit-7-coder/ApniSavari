using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class BookingSeat
{
    public long BookingSeatId { get; set; }

    public long BookingId { get; set; }

    public long TripSeatInventoryId { get; set; }

    public long BookingPassengerId { get; set; }

    public long FromTripStopId { get; set; }

    public long ToTripStopId { get; set; }

    public string? FareAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual ICollection<BoardingRecord> BoardingRecords { get; set; } = new List<BoardingRecord>();

    public virtual Booking Booking { get; set; } = null!;

    public virtual BookingPassenger BookingPassenger { get; set; } = null!;
}
