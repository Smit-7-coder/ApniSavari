using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class OperatorPenalty
{
    public long OperatorPenaltyId { get; set; }

    public long OperatorId { get; set; }

    public long TripId { get; set; }

    public long DisruptionId { get; set; }

    public string? ReasonCode { get; set; }

    public int? AffectedPassengerCount { get; set; }

    public decimal? Amount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual OperatorDisruption Disruption { get; set; } = null!;

    public virtual Operator Operator { get; set; } = null!;
}
