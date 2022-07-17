using Discount.gRPC.DbContext;
using Discount.gRPC.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly CouponContext _context;

    public DiscountRepository(CouponContext context)
    {
        _context = context;
    }
    
    public async Task<Coupon> GetCoupon(string productName)
    {
        var coupon = await _context.Coupons.FirstOrDefaultAsync(p => p.ProductName ==productName);

        if (coupon == null)
        {
            return new Coupon
            {
                ProductName = "Not Available",
                Amount = 0,
                Description = "Not Available"
            };
        }

        return coupon;
        // Query ORM
        // connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon Where ProductName = @ProductName",
        // new { ProductName =productName }
        // );
    }

    public async  Task<Coupon> UpdateDiscount(Coupon coupon)
    {
        var newCoupon = await _context.Coupons.FirstOrDefaultAsync(p => p.ProductName ==coupon.ProductName);
        
        if (newCoupon == null) return newCoupon;
        
        
        newCoupon.Amount = coupon.Amount;
        newCoupon.Description = coupon.Description;

        await SaveChanges();
        return newCoupon;
    }

    public async Task<Coupon> CreateDiscount(Coupon coupon)
    {
        await _context.Coupons.AddAsync(coupon);
        await SaveChanges();
        return (coupon);
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        var newCoupon = await _context.Coupons.FirstOrDefaultAsync(p => p.ProductName ==productName);
        _context.Coupons.Remove(newCoupon);
        
            return await SaveChanges();
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}