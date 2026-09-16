using System;
using System.Collections.Generic;

namespace ApniSavari.Infrastructure.Persistence.Entities;

public partial class Coupon
{
    public long CouponId { get; set; }

    public string? Code { get; set; }

    public string? DiscountType { get; set; }

    public decimal? DiscountValue { get; set; }

    public decimal? MaxDiscountAmount { get; set; }

    public decimal? MinBookingAmount { get; set; }

    public string? FirstBookingOnly { get; set; }

    public DateTime? StartsAtUtc { get; set; }

    public DateTime? EndsAtUtc { get; set; }

    public string? UsageLimit { get; set; }

    public string? PerUserUsageLimit { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<CouponUsage> CouponUsages { get; set; } = new List<CouponUsage>();
}
