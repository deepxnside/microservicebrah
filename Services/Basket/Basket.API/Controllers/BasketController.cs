using System.Net;
using Basket.API.Entities;
using Basket.API.gRPCServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;



[ApiController]
[Route("api/v1/[controller]")]
public class BasketController :ControllerBase
{
    private readonly IBasketRepository _repository;
    private readonly DiscountgRPCServices _discountgRpcServices;



    public BasketController(IBasketRepository repository,DiscountgRPCServices discountgRpcServices)
    {
        _repository = repository;
        _discountgRpcServices = discountgRpcServices;
    }
    
    
    [HttpGet("{Username}",Name="GetBasket")]
    [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string Username)
    {
        
        
        return Ok(await _repository.GetBasket(Username) ?? new ShoppingCart(Username));
        // return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> Updatebasket([FromBody] ShoppingCart basket)
    {
        foreach (var item in basket.Items)
        {
            var coupon = await _discountgRpcServices.GetDiscount(item.ProductName);
            item.Price -= coupon.Amount;
        }
        
        return Ok(await _repository.UpdateBasket(basket));
    }

    [HttpDelete("{Username}",Name="DeleteBasket")]
    [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> DeleteBasket(string Username)
    {
        await _repository.DeleteBasket(Username);
        return NoContent();
    } 
}