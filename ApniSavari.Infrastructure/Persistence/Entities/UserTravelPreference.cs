using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class UserTravelPreference
{
    public long UserId { get; set; }

    public bool? PreferWindow { get; set; }

    public bool? PreferMiddle { get; set; }

    public bool? PreferFront { get; set; }

    public bool? PreferLower { get; set; }

    public bool? PreferUpper { get; set; }

    public DateTime UpdatedAtUtc { get; set; }
}
