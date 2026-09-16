using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class NotificationTemplate
{
    public long TemplateId { get; set; }

    public string? TemplateCode { get; set; }

    public string? Channel { get; set; }

    public string? SubjectTemplate { get; set; }

    public string? BodyTemplate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
