using StoreApi.Models;

namespace StoreApi.Services
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCartItem> GetCartItems(string shoppingCartId);
        void AddToCart(ShoppingCartItem item);
        void UpdateCartItem(ShoppingCartItem item);
        void RemoveFromCart(int id);
        decimal GetCartTotal(string shoppingCartId);
    }
}
