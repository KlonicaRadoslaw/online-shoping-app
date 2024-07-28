using online_shoping.Models.Dtos;
using online_shoping_app.Api.Entities;

namespace online_shoping_app.Api.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto);
        Task<CartItem> DeleteItem(int id);
        Task<CartItem> GetItemById(int id);
        Task<IEnumerable<CartItem>> GetItems(int userId);
    }
}
