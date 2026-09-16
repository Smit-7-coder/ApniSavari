using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class OfferUsage
{
    public long OfferUsageId { get; set; }

    public long OfferId { get; set; }

    public long UserId { get; set; }

    public long BookingId { get; set; }

    public decimal? DiscountAmount { get; set; }

    public DateTime? UsedAtUtc { get; set; }

    public virtual Offer Offer { get; set; } = null!;
}
