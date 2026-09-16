using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class OperatorDocument
{
    public long OperatorDocumentId { get; set; }

    public long OperatorId { get; set; }

    public string? DocumentType { get; set; }

    public string? DocumentNumber { get; set; }

    public string? FileUrl { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly? ExpiresOn { get; set; }

    public long VerifiedByUserId { get; set; }

    public DateTime? VerifiedAtUtc { get; set; }

    public string? RejectionReason { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public virtual Operator Operator { get; set; } = null!;
}
