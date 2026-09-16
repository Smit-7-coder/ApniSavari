using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Stop
{
    public long StopId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? StateCode { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Route> RouteDestinationStops { get; set; } = new List<Route>();

    public virtual ICollection<Route> RouteOriginStops { get; set; } = new List<Route>();

    public virtual ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
}
