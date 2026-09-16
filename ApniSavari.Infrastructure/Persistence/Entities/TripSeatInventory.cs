using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class TripSeatInventory
{
    public long TripSeatInventoryId { get; set; }

    public long TripId { get; set; }

    public long SeatLayoutSeatId { get; set; }

    public string? SeatCodeSnapshot { get; set; }

    public string? SeatTypeSnapshot { get; set; }

    public string? DeckSnapshot { get; set; }

    public string Status { get; set; } = null!;

    public string? BlockedReason { get; set; }

    public virtual ICollection<SeatHold> SeatHolds { get; set; } = new List<SeatHold>();
}
