using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class RouteStop
{
    public long RouteStopId { get; set; }

    public long RouteId { get; set; }

    public long StopId { get; set; }

    public int? SequenceNo { get; set; }

    public int? ScheduledOffsetMinutes { get; set; }

    public string? BoardingAllowed { get; set; }

    public string? DroppingAllowed { get; set; }

    public string? RestStop { get; set; }

    public int? DefaultStopDurationMinutes { get; set; }

    public virtual Route Route { get; set; } = null!;

    public virtual Stop Stop { get; set; } = null!;
}
