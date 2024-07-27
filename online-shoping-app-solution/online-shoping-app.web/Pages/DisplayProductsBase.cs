using Microsoft.AspNetCore.Components;
using online_shoping.Models.Dtos;

namespace online_shoping_app.web.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
