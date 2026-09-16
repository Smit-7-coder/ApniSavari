using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class OperatorSettlement
{
    public long OperatorSettlementId { get; set; }

    public long OperatorId { get; set; }

    public string? SettlementReference { get; set; }

    public decimal? GrossAmount { get; set; }

    public decimal? CommissionAmount { get; set; }

    public decimal? RefundAmount { get; set; }

    public decimal? PenaltyAmount { get; set; }

    public decimal? AdjustmentAmount { get; set; }

    public decimal? NetAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? EligibleAtUtc { get; set; }

    public DateTime? SettledAtUtc { get; set; }

    public virtual ICollection<SettlementItem> SettlementItems { get; set; } = new List<SettlementItem>();
}
