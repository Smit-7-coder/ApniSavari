using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Refund
{
    public long RefundId { get; set; }

    public long BookingId { get; set; }

    public long PaymentId { get; set; }

    public decimal? RequestedAmount { get; set; }

    public decimal? ApprovedAmount { get; set; }

    public string? ReasonCode { get; set; }

    public long? ProviderRefundId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? RequestedAtUtc { get; set; }

    public DateTime? ProcessedAtUtc { get; set; }

    public virtual Payment Payment { get; set; } = null!;
}
