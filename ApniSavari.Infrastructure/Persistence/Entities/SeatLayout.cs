using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class SeatLayout
{
    public long SeatLayoutId { get; set; }

    public long OperatorId { get; set; }

    public string? Name { get; set; }

    public short? TotalSeats { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();

    public virtual ICollection<SeatLayoutSeat> SeatLayoutSeats { get; set; } = new List<SeatLayoutSeat>();
}
