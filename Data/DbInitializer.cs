using Microsoft.EntityFrameworkCore;
using StoreApi.Models;

namespace StoreApi.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<StoreDbContext>();

                
                context.Database.Migrate();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { CategoryName = "Electronics", Description = "Devices and gadgets" },
                        new Category { CategoryName = "Clothing", Description = "Men and Women fashion" },
                        new Category { CategoryName = "Home Appliances", Description = "Kitchen and home products" }
                    );

                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Name = "Smartphone",
                            Price = 599.99M,
                            ShortDescription = "Latest model smartphone",
                            LongDescription = "A high-end smartphone with all the latest features, including 5G connectivity and an OLED display.",
                            CategoryId = context.Categories.First(c => c.CategoryName == "Electronics").CategoryId,
                            InStock = true
                        },
                        new Product
                        {
                            Name = "Laptop",
                            Price = 1299.99M,
                            ShortDescription = "High-performance laptop",
                            LongDescription = "Perfect for gaming and professional work, this laptop features a powerful processor and a long-lasting battery.",
                            CategoryId = context.Categories.First(c => c.CategoryName == "Electronics").CategoryId,
                            InStock = true
                        },
                        new Product
                        {
                            Name = "T-Shirt",
                            Price = 19.99M,
                            ShortDescription = "Comfortable cotton T-shirt",
                            LongDescription = "Made from 100% organic cotton, this T-shirt is perfect for everyday wear.",
                            CategoryId = context.Categories.First(c => c.CategoryName == "Clothing").CategoryId,
                            InStock = true
                        },
                        new Product
                        {
                            Name = "Blender",
                            Price = 49.99M,
                            ShortDescription = "Multipurpose kitchen blender",
                            LongDescription = "A high-speed blender for making smoothies, soups, and more. Easy to clean and durable.",
                            CategoryId = context.Categories.First(c => c.CategoryName == "Home Appliances").CategoryId,
                            InStock = true
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
