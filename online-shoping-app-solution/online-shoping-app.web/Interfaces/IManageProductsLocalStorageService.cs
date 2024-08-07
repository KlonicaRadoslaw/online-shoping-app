using online_shoping.Models.Dtos;

namespace online_shoping_app.web.Interfaces
{
    public interface IManageProductsLocalStorageService
    {
        Task<IEnumerable<ProductDto>> GetCollection();
        Task RemoveCollection();
    }
}
