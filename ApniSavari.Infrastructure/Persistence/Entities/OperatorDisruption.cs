using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class OperatorDisruption
{
    public long OperatorDisruptionId { get; set; }

    public long TripId { get; set; }

    public long OperatorId { get; set; }

    public string? DisruptionType { get; set; }

    public string? Reason { get; set; }

    public long CreatedByUserId { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public string Status { get; set; } = null!;

    public virtual Operator Operator { get; set; } = null!;

    public virtual ICollection<OperatorPenalty> OperatorPenalties { get; set; } = new List<OperatorPenalty>();
}
