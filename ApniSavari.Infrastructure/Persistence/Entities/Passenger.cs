using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Passenger
{
    public long PassengerId { get; set; }

    public long UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public byte? Age { get; set; }

    public string? Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual ICollection<BookingPassenger> BookingPassengers { get; set; } = new List<BookingPassenger>();
}
