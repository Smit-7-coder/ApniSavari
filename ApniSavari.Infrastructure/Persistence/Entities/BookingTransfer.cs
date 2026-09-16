using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class BookingTransfer
{
    public long BookingTransferId { get; set; }

    public long BookingId { get; set; }

    public long FromTripId { get; set; }

    public long ToTripId { get; set; }

    public decimal? TransferFee { get; set; }

    public string Status { get; set; } = null!;

    public string? Reason { get; set; }

    public DateTime? RequestedAtUtc { get; set; }

    public DateTime? CompletedAtUtc { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
