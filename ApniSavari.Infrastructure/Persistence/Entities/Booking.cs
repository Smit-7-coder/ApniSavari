using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Booking
{
    public long BookingId { get; set; }

    public string? BookingReference { get; set; }

    public long UserId { get; set; }

    public long TripId { get; set; }

    public long BoardingTripStopId { get; set; }

    public long DroppingTripStopId { get; set; }

    public DateTime? BookedAtUtc { get; set; }

    public string? CurrencyCode { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? ServiceFee { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CancelledAtUtc { get; set; }

    public DateTime UpdatedAtUtc { get; set; }

    public virtual ICollection<BookingPassenger> BookingPassengers { get; set; } = new List<BookingPassenger>();

    public virtual ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

    public virtual ICollection<BookingTransfer> BookingTransfers { get; set; } = new List<BookingTransfer>();
}
