using Microsoft.EntityFrameworkCore;
using ApniSavari.Infrastructure.Persistence.Entities;

namespace ApniSavari.Infrastructure.Persistence.Context;

public class ApniSavariDbContext : DbContext
{
    public ApniSavariDbContext(DbContextOptions<ApniSavariDbContext> options)
        : base(options)
    {
    }

    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<BoardingRecord> BoardingRecords => Set<BoardingRecord>();
    public DbSet<BookingPassenger> BookingPassengers => Set<BookingPassenger>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<BookingSeat> BookingSeats => Set<BookingSeat>();
    public DbSet<BookingTransfer> BookingTransfers => Set<BookingTransfer>();
    public DbSet<BusAmenity> BusAmenities => Set<BusAmenity>();
    public DbSet<Bus> Buses => Set<Bus>();
    public DbSet<BusType> BusTypes => Set<BusType>();
    public DbSet<Complaint> Complaints => Set<Complaint>();
    public DbSet<Conductor> Conductors => Set<Conductor>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<CouponUsage> CouponUsages => Set<CouponUsage>();
    public DbSet<DisruptionAffectedBooking> DisruptionAffectedBookings => Set<DisruptionAffectedBooking>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<MediaFile> MediaFiles => Set<MediaFile>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<NotificationTemplate> NotificationTemplates => Set<NotificationTemplate>();
    public DbSet<Offer> Offers => Set<Offer>();
    public DbSet<OfferUsage> OfferUsages => Set<OfferUsage>();
    public DbSet<OperatorBankAccount> OperatorBankAccounts => Set<OperatorBankAccount>();
    public DbSet<OperatorDisruption> OperatorDisruptions => Set<OperatorDisruption>();
    public DbSet<OperatorDocument> OperatorDocuments => Set<OperatorDocument>();
    public DbSet<OperatorPenalty> OperatorPenalties => Set<OperatorPenalty>();
    public DbSet<Operator> Operators => Set<Operator>();
    public DbSet<OperatorSettlement> OperatorSettlements => Set<OperatorSettlement>();
    public DbSet<OperatorUser> OperatorUsers => Set<OperatorUser>();
    public DbSet<Passenger> Passengers => Set<Passenger>();
    public DbSet<PaymentProviderAccount> PaymentProviderAccounts => Set<PaymentProviderAccount>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<PaymentTransaction> PaymentTransactions => Set<PaymentTransaction>();
    public DbSet<PaymentTransfer> PaymentTransfers => Set<PaymentTransfer>();
    public DbSet<PricingRule> PricingRules => Set<PricingRule>();
    public DbSet<Refund> Refunds => Set<Refund>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Route> Routes => Set<Route>();
    public DbSet<RouteStop> RouteStops => Set<RouteStop>();
    public DbSet<SeatHold> SeatHolds => Set<SeatHold>();
    public DbSet<SeatLayout> SeatLayouts => Set<SeatLayout>();
    public DbSet<SeatLayoutSeat> SeatLayoutSeats => Set<SeatLayoutSeat>();
    public DbSet<SettlementItem> SettlementItems => Set<SettlementItem>();
    public DbSet<Stop> Stops => Set<Stop>();
    public DbSet<SystemConfiguration> SystemConfigurations => Set<SystemConfiguration>();
    public DbSet<TripBuse> TripBuses => Set<TripBuse>();
    public DbSet<TripFare> TripFares => Set<TripFare>();
    public DbSet<Trip> Trips => Set<Trip>();
    public DbSet<TripSeatInventory> TripSeatInventory => Set<TripSeatInventory>();
    public DbSet<TripStaffAssignment> TripStaffAssignments => Set<TripStaffAssignment>();
    public DbSet<TripStop> TripStops => Set<TripStop>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserTravelPreference> UserTravelPreferences => Set<UserTravelPreference>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApniSavariDbContext).Assembly);
    }
}