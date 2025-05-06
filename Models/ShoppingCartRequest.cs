namespace StoreApi.Models
{
    public class ShoppingCartRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartId { get; set; } = string.Empty;
    }
}
