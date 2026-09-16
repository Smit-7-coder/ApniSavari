using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class OperatorUser
{
    public long OperatorUserId { get; set; }

    public long OperatorId { get; set; }

    public long UserId { get; set; }

    public bool? IsPrimary { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual Operator Operator { get; set; } = null!;
}
