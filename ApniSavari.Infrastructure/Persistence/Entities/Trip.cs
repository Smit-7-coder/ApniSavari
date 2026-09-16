using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Trip
{
    public long TripId { get; set; }

    public long OperatorId { get; set; }

    public long RouteId { get; set; }

    public DateOnly? ServiceDate { get; set; }

    public DateTime? OriginDepartureAtLocal { get; set; }

    public long? OriginTimeZoneId { get; set; }

    public string? TripCode { get; set; }

    public DateTime? BookingOpenAtUtc { get; set; }

    public DateTime? BookingCloseAtUtc { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual ICollection<TripBuse> TripBuses { get; set; } = new List<TripBuse>();

    public virtual ICollection<TripFare> TripFares { get; set; } = new List<TripFare>();

    public virtual ICollection<TripStaffAssignment> TripStaffAssignments { get; set; } = new List<TripStaffAssignment>();

    public virtual ICollection<TripStop> TripStops { get; set; } = new List<TripStop>();
}
