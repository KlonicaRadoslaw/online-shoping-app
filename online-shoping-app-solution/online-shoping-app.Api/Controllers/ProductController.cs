using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_shoping.Models.Dtos;
using online_shoping_app.Api.Extensions;
using online_shoping_app.Api.Interfaces;

namespace online_shoping_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetItems();

                if(products == null) 
                    return NotFound();
                else
                {
                    var productDtos = products.ConvertToDto();

                    return Ok(productDtos);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem([FromRoute] int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);

                if (product == null)
                    return NotFound();
                else
                {
                    var productDto = product.ConvertToDto();

                    return Ok(productDto);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route(nameof(GetProductCategories))]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            try
            {
                var productCategories = await _productRepository.GetCategories();
                var productCategoryDtos = productCategories.ConvertToDto();

                return Ok(productCategoryDtos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var products = await _productRepository.GetItemsByCategory(categoryId);
                var productDtos = products.ConvertToDto();

                return Ok(productDtos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error retrieving data from the database");
            }
        }
    }
}
