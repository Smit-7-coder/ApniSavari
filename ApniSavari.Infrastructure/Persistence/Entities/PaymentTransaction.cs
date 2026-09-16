using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class PaymentTransaction
{
    public long PaymentTransactionId { get; set; }

    public long PaymentId { get; set; }

    public long BookingId { get; set; }

    public string? TransactionType { get; set; }

    public decimal? Amount { get; set; }

    public long? ProviderTransactionId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? OccurredAtUtc { get; set; }

    public virtual Payment Payment { get; set; } = null!;
}
