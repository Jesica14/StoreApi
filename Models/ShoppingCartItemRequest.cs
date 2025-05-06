namespace StoreApi.Models
{
    public class ShoppingCartItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartId { get; set; } = string.Empty;
    }
}
