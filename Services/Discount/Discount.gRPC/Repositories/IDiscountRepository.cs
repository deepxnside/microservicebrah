using Discount.gRPC.Entities;

namespace Discount.gRPC.Repositories;

public interface IDiscountRepository
{
    Task<Coupon> GetCoupon(string productName);
    Task<Coupon> UpdateDiscount(Coupon coupon);
    Task<Coupon> CreateDiscount(Coupon coupon);
    Task<bool> DeleteDiscount(string productName);

    Task<bool> SaveChanges();
}