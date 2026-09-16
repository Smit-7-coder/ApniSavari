using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class BoardingRecord
{
    public long BoardingRecordId { get; set; }

    public long BookingSeatId { get; set; }

    public long TripStopId { get; set; }

    public long ScannedByUserId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ScannedAtUtc { get; set; }

    public virtual BookingSeat BookingSeat { get; set; } = null!;
}
