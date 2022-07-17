using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CouponController : ControllerBase
{
    private readonly IDiscountRepository _repository;

    public CouponController(IDiscountRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("{coupon}",Name="GenerateNewCoupon")]
    public async Task<ActionResult<Coupon>> GenerateNewCoupon(Coupon coupon)
    {
        return Ok(await _repository.CreateDiscount(coupon));
    }

    [HttpGet("{productName}",Name="GetCoupon")]
    public async Task<ActionResult<Coupon>> GetCoupon(string productName)
    {
        return Ok(await _repository.GetCoupon(productName));
    }
    
    [HttpDelete("{coupon}",Name="DeleteCoupon")] 
    public async Task<ActionResult<Coupon>> DeleteCoupon(Coupon coupon)
    {
        return Ok(await _repository.DeleteDiscount(coupon));
    }
    [HttpPatch("{coupon}",Name="UpdateCoupon")]
    public async Task<ActionResult<Coupon>> UpdateCoupon(Coupon coupon)
    {
        return Ok(await _repository.UpdateDiscount(coupon));
    }
    
}