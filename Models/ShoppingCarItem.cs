namespace StoreApi.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
        public string ShoppingCartId { get; set; } = string.Empty;
    }
}
