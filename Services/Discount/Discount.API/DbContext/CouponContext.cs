using Discount.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.DbContext;

public class CouponContext: Microsoft.EntityFrameworkCore.DbContext
{
    public CouponContext(DbContextOptions<CouponContext> opts) : base(opts)
    {
        Database.EnsureCreated();
    }
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).SeedData();
    }*/
    
    public DbSet<Coupon> Coupons { get; set; }
}