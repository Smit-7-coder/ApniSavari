using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Bus
{
    public long BusId { get; set; }

    public long OperatorId { get; set; }

    public long BusTypeId { get; set; }

    public string? RegistrationNumber { get; set; }

    public string? Manufacturer { get; set; }

    public string? Model { get; set; }

    public long SeatLayoutId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public DateTime UpdatedAtUtc { get; set; }

    public virtual BusType BusType { get; set; } = null!;

    public virtual SeatLayout SeatLayout { get; set; } = null!;
}
