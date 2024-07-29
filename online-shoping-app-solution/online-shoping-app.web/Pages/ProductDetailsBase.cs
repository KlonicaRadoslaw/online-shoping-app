using Microsoft.AspNetCore.Components;
using online_shoping.Models.Dtos;
using online_shoping_app.web.Interfaces;

namespace online_shoping_app.web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItemById(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var carItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
