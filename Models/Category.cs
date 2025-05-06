﻿namespace StoreApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
