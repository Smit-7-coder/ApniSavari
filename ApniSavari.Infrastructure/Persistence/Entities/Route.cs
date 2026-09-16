using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Route
{
    public long RouteId { get; set; }

    public long OperatorId { get; set; }

    public string? RouteName { get; set; }

    public long OriginStopId { get; set; }

    public long DestinationStopId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual Stop DestinationStop { get; set; } = null!;

    public virtual Stop OriginStop { get; set; } = null!;

    public virtual ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
}
