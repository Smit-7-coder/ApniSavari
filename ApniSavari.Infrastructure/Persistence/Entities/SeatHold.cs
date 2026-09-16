using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class SeatHold
{
    public long SeatHoldId { get; set; }

    public long TripSeatInventoryId { get; set; }

    public long UserId { get; set; }

    public long BookingId { get; set; }

    public string? HoldToken { get; set; }

    public DateTime? HeldAtUtc { get; set; }

    public DateTime? ExpiresAtUtc { get; set; }

    public string Status { get; set; } = null!;

    public virtual TripSeatInventory TripSeatInventory { get; set; } = null!;
}
