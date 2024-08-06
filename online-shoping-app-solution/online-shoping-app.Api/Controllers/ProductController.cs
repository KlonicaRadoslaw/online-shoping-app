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
                var productCategories = await _productRepository.GetCategories();

                if(products == null || productCategories == null) 
                    return NotFound();
                else
                {
                    var productDtos = products.ConvertToDto(productCategories);

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
                    var productCategory = await _productRepository.GetCategoryById(product.CategoryId);

                    var productDto = product.ConvertToDto(productCategory);

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
    }
}
