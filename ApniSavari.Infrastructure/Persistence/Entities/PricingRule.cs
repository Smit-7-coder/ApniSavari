using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class PricingRule
{
    public long PricingRuleId { get; set; }

    public long OperatorId { get; set; }

    public long RouteId { get; set; }

    public string? SeatType { get; set; }

    public decimal? CommissionPercent { get; set; }

    public decimal? ServiceFee { get; set; }

    public string? EffectiveFromUtc { get; set; }

    public string? EffectiveToUtc { get; set; }

    public string Status { get; set; } = null!;
}
