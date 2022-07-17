using Discount.gRPC.Entities;
using Discount.gRPC.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.DbContext;

public class CouponContext: Microsoft.EntityFrameworkCore.DbContext
{
    public CouponContext(DbContextOptions<CouponContext> opts) : base(opts)
    {
        
    }

    
    public DbSet<Coupon> Coupons { get; set; }
}