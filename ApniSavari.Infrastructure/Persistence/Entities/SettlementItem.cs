using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class SettlementItem
{
    public long SettlementItemId { get; set; }

    public long OperatorSettlementId { get; set; }

    public long BookingId { get; set; }

    public long PaymentTransferId { get; set; }

    public decimal? GrossAmount { get; set; }

    public decimal? CommissionAmount { get; set; }

    public decimal? RefundAmount { get; set; }

    public decimal? PenaltyAmount { get; set; }

    public decimal? AdjustmentAmount { get; set; }

    public decimal? NetAmount { get; set; }

    public virtual OperatorSettlement OperatorSettlement { get; set; } = null!;
}
