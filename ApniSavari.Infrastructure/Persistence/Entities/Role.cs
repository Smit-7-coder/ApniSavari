using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Role
{
    public long RoleId { get; set; }

    public string? RoleName { get; set; }

    public bool? IsActive { get; set; }
}
