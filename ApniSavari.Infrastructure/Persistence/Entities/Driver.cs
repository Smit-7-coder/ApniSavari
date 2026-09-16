using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Driver
{
    public long DriverId { get; set; }

    public long OperatorId { get; set; }

    public long UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? LicenseNumberMasked { get; set; }

    public DateOnly? LicenseExpiresOn { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual ICollection<TripStaffAssignment> TripStaffAssignments { get; set; } = new List<TripStaffAssignment>();
}
