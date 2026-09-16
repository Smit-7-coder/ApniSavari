using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Operator
{
    public long OperatorId { get; set; }

    public string? LegalName { get; set; }

    public string? DisplayName { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? BusinessType { get; set; }

    public string? Pan { get; set; }

    public string? Gstin { get; set; }

    public string? Address { get; set; }

    public string? KycStatus { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public DateTime UpdatedAtUtc { get; set; }

    public virtual ICollection<OperatorBankAccount> OperatorBankAccounts { get; set; } = new List<OperatorBankAccount>();

    public virtual ICollection<OperatorDisruption> OperatorDisruptions { get; set; } = new List<OperatorDisruption>();

    public virtual ICollection<OperatorDocument> OperatorDocuments { get; set; } = new List<OperatorDocument>();

    public virtual ICollection<OperatorPenalty> OperatorPenalties { get; set; } = new List<OperatorPenalty>();

    public virtual ICollection<OperatorSettlement> OperatorSettlements { get; set; } = new List<OperatorSettlement>();

    public virtual ICollection<OperatorUser> OperatorUsers { get; set; } = new List<OperatorUser>();
}
