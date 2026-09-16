using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class SystemConfiguration
{
    public long ConfigurationId { get; set; }

    public string? ConfigurationKey { get; set; }

    public string? ConfigurationValue { get; set; }

    public string? DataType { get; set; }

    public string? Description { get; set; }

    public long UpdatedByUserId { get; set; }

    public DateTime UpdatedAtUtc { get; set; }
}
