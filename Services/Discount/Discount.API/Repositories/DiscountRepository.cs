using Discount.API.DbContext;
using Discount.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Repositories;

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

    public async  Task<bool> UpdateDiscount(Coupon coupon)
    {
        var newCoupon = await _context.Coupons.FirstOrDefaultAsync(p => p.ProductName ==coupon.ProductName);
        
        if (newCoupon == null) return await SaveChanges();
        
        
        newCoupon.Amount = coupon.Amount;
        newCoupon.Description = coupon.Description;

        return await SaveChanges();
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        await _context.Coupons.AddAsync(coupon);
        return await SaveChanges();
    }

    public async Task<bool> DeleteDiscount(Coupon coupon)
    {
        _context.Coupons.Remove(coupon);
        
            return await SaveChanges();
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}