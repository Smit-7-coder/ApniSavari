using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class OperatorBankAccount
{
    public long OperatorBankAccountId { get; set; }

    public long OperatorId { get; set; }

    public string? AccountHolderName { get; set; }

    public string? AccountNumberMasked { get; set; }

    public string? BankName { get; set; }

    public string? Ifsc { get; set; }

    public long PaymentProviderAccountId { get; set; }

    public string? VerificationStatus { get; set; }

    public bool? IsPrimary { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public virtual Operator Operator { get; set; } = null!;
}
