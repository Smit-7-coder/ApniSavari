using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class AuditLog
{
    public long AuditLogId { get; set; }

    public long UserId { get; set; }

    public string? Action { get; set; }

    public string? EntityName { get; set; }

    public long? EntityId { get; set; }

    public string? OldValuesJson { get; set; }

    public string? NewValuesJson { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public DateTime CreatedAtUtc { get; set; }
}
