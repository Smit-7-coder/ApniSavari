using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Notification
{
    public long NotificationId { get; set; }

    public long UserId { get; set; }

    public long BookingId { get; set; }

    public string? Channel { get; set; }

    public long TemplateId { get; set; }

    public string? Destination { get; set; }

    public string? PayloadJson { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ScheduledAtUtc { get; set; }

    public DateTime? SentAtUtc { get; set; }

    public long? ProviderMessageId { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public virtual NotificationTemplate Template { get; set; } = null!;
}
