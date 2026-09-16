using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class TripStaffAssignment
{
    public long TripStaffAssignmentId { get; set; }

    public long TripId { get; set; }

    public long DriverId { get; set; }

    public long ConductorId { get; set; }

    public DateTime? AssignedAtUtc { get; set; }

    public DateTime? ContactReleaseAtUtc { get; set; }

    public string Status { get; set; } = null!;

    public virtual Conductor Conductor { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
