using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class DisruptionAffectedBooking
{
    public long DisruptionAffectedBookingId { get; set; }

    public long OperatorDisruptionId { get; set; }

    public long BookingId { get; set; }

    public decimal? PassengerRefundPercent { get; set; }

    public decimal? PenaltyAmount { get; set; }

    public string? ResolutionStatus { get; set; }
}
