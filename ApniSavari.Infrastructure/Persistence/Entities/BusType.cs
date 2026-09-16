using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class BusType
{
    public long BusTypeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();
}
