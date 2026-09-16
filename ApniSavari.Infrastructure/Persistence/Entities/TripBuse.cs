using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class TripBuse
{
    public long TripBusId { get; set; }

    public long TripId { get; set; }

    public long BusId { get; set; }

    public string? RegistrationNumberSnapshot { get; set; }

    public DateTime? AssignedAtUtc { get; set; }

    public DateTime? BusNumberAllocatedAtUtc { get; set; }

    public bool? IsPrimary { get; set; }

    public string Status { get; set; } = null!;

    public string? ReplacementReason { get; set; }

    public virtual Trip Trip { get; set; } = null!;
}
