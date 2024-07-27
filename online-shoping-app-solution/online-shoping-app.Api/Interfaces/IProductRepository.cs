using online_shoping_app.Api.Entities;

namespace online_shoping_app.Api.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetProductById(int id);
        Task<ProductCategory> GetCategoryById(int id);
    }
}
