using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class CouponUsage
{
    public long CouponUsageId { get; set; }

    public long CouponId { get; set; }

    public long UserId { get; set; }

    public long BookingId { get; set; }

    public decimal? DiscountAmount { get; set; }

    public DateTime? UsedAtUtc { get; set; }

    public virtual Coupon Coupon { get; set; } = null!;
}
