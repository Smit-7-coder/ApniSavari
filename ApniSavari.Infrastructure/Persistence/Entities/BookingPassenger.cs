using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class BookingPassenger
{
    public long BookingPassengerId { get; set; }

    public long BookingId { get; set; }

    public long PassengerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public byte? Age { get; set; }

    public string? Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

    public virtual Passenger Passenger { get; set; } = null!;
}
