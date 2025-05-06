using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Models;

namespace StoreApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreDbContext _context;

        public CategoryService(StoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.Include(c => c.Products).ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return _context.Categories.Include(c => c.Products)
                                      .FirstOrDefault(c => c.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
