using Microsoft.EntityFrameworkCore;
using online_shoping_app.Api.Data;
using online_shoping_app.Api.Entities;
using online_shoping_app.Api.Interfaces;

namespace online_shoping_app.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await _context.ProductCategories.ToListAsync();

            return categories;
        }

        public async Task<ProductCategory> GetCategoryById(int id)
        {
            var category = await _context.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await _context.Products
                                         .Include(p => p.ProductCategory)
                                         .ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            var products = await _context.Products
                                         .Include(p => p.ProductCategory)
                                         .Where(p => p.CategoryId == id)
                                         .ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products
                                .Include(p => p.ProductCategory)
                                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }
    }
}
