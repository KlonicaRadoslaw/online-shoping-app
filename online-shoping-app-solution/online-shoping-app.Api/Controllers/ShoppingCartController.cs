using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_shoping.Models.Dtos;
using online_shoping_app.Api.Extensions;
using online_shoping_app.Api.Interfaces;

namespace online_shoping_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository,IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("{userId}/GetItems")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                var cartItems = await _shoppingCartRepository.GetItems(userId);

                if(cartItems == null)
                    return NotFound();

                var products = await _productRepository.GetItems();

                if (products == null)
                    throw new Exception("No products exist in the system");

                var cartItemsDto = cartItems.ConvertToDto(products);

                return Ok(cartItemsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItem = await _shoppingCartRepository.GetItemById(id);
                if(cartItem == null)
                    return NotFound();

                var product = await _productRepository.GetProductById(cartItem.ProductId);
                if (product == null)
                    return NotFound();

                var cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
