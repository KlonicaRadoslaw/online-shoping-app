using online_shoping.Models.Dtos;

namespace online_shoping_app.web.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItemById(int id);
        Task<IEnumerable<ProductCategoryDto>> GetProductCategories();
    }
}
