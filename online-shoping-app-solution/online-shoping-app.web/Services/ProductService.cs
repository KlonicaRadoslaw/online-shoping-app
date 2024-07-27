using online_shoping.Models.Dtos;
using online_shoping_app.web.Interfaces;
using System.Net.Http.Json;

namespace online_shoping_app.web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
                return products;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
