using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Models;

namespace StoreApi.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly StoreDbContext _context;

        public ShoppingCartService(StoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ShoppingCartItem> GetCartItems(string shoppingCartId)
        {
            return _context.ShoppingCartItems
                           .Include(c => c.Product)
                           .Where(c => c.ShoppingCartId == shoppingCartId)
                           .ToList();
        }

        public void AddToCart(ShoppingCartItem item)
        {
            var existingItem = _context.ShoppingCartItems
                                       .FirstOrDefault(c => c.ShoppingCartId == item.ShoppingCartId && c.ProductId == item.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _context.ShoppingCartItems.Add(item);
            }

            _context.SaveChanges();
        }

        public void UpdateCartItem(ShoppingCartItem item)
        {
            _context.ShoppingCartItems.Update(item);
            _context.SaveChanges();
        }

        public void RemoveFromCart(int id)
        {
            var item = _context.ShoppingCartItems.Find(id);
            if (item != null)
            {
                _context.ShoppingCartItems.Remove(item);
                _context.SaveChanges();
            }
        }

        public decimal GetCartTotal(string shoppingCartId)
        {
            return _context.ShoppingCartItems
                           .Where(c => c.ShoppingCartId == shoppingCartId)
                           .Sum(c => c.Product.Price * c.Quantity);
        }
    }
}
