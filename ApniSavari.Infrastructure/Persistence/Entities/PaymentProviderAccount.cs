using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class PaymentProviderAccount
{
    public long PaymentProviderAccountId { get; set; }

    public long OperatorId { get; set; }

    public string? ProviderName { get; set; }

    public long? ExternalAccountId { get; set; }

    public string? KycStatus { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }
}
