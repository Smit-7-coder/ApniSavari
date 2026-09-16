using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class User
{
    public long UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public string Status { get; set; } = null!;

    public bool? IsPhoneVerified { get; set; }

    public bool? IsEmailVerified { get; set; }
    public bool IsEmailverified { get; internal set; }
    public DateTime CreatedAtUtc { get; set; }

    public DateTime UpdatedAtUtc { get; set; }
}
