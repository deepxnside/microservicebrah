using System.Text.Json.Serialization;
using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories;

public class BasketRepository: IBasketRepository
{
    private readonly IDistributedCache _redis;

    public BasketRepository(IDistributedCache redis )
    {
        _redis = redis;
    }
    public async Task<ShoppingCart> GetBasket(string UserName)
    {
        var basket = await _redis.GetStringAsync(UserName);
        if (String.IsNullOrEmpty(basket))
        {
            return null; 
        }

        return JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
    {
        await _redis.SetStringAsync(shoppingCart.Username,JsonConvert.SerializeObject(shoppingCart));
        return await GetBasket(shoppingCart.Username);
    }

    public async Task DeleteBasket(string Username)
    {
        await _redis.RemoveAsync(Username);
    }
}