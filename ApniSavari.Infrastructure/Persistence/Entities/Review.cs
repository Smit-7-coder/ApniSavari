using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Review
{
    public long ReviewId { get; set; }

    public long BookingId { get; set; }

    public long UserId { get; set; }

    public long OperatorId { get; set; }

    public long TripId { get; set; }

    public byte? Rating { get; set; }

    public string? ReviewText { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }
}
