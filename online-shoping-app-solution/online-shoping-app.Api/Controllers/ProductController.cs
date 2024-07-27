﻿using Microsoft.AspNetCore.Http;
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
    }
}