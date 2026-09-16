using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Complaint
{
    public long ComplaintId { get; set; }

    public long BookingId { get; set; }

    public long UserId { get; set; }

    public long OperatorId { get; set; }

    public string? Category { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public long AssignedToUserId { get; set; }

    public string? ResolutionNotes { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? ResolvedAtUtc { get; set; }
}
