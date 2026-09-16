using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class PaymentTransfer
{
    public long PaymentTransferId { get; set; }

    public long PaymentId { get; set; }

    public long BookingId { get; set; }

    public long OperatorId { get; set; }

    public decimal? Amount { get; set; }

    public long? ProviderTransferId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? SettledAtUtc { get; set; }

    public virtual Payment Payment { get; set; } = null!;
}
