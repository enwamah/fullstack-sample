using Microsoft.AspNetCore.Mvc;
using ProductsWebApi.DTOs.Product;
using ProductsWebApi.Services;

namespace ProductsWebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductsAsync(ProductPost request)
        {
            try
            {
                var result = await _productService.CreateAsync(request);
                return Created("/api/products", result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
