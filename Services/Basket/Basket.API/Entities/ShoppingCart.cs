namespace Basket.API.Entities;

public class ShoppingCart
{
    public string Username { get; set; }   
    public IEnumerable<CartItem> Items { get; set; }

    public ShoppingCart() { }

    public ShoppingCart(string username)
    {
        Username = username;
    }

    public decimal TotalPrice
    {
        get
        {
            decimal totalprice = 0;
            if (Items == null)
                return totalprice;
            foreach (var item in Items)
            {
                totalprice += item.Price * item.Quantity;
            }

            return totalprice;
        }
    }
}