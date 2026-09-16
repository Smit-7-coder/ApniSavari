using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Amenity
{
    public long AmenityId { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }
}
