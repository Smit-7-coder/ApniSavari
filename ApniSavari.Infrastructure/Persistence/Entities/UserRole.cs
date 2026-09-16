using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class UserRole
{
    public long UserId { get; set; }

    public long RoleId { get; set; }

    public DateTime? AssignedAtUtc { get; set; }
}
