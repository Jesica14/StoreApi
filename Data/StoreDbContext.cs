using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StoreApi.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

