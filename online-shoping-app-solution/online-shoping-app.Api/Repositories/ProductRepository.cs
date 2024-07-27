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

        public Task<ProductCategory> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
