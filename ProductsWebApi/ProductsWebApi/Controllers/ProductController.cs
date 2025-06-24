using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsWebApi.Data;
using ProductsWebApi.DTOs.Product;
using ProductsWebApi.Models;

namespace ProductsWebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            List<ProductGet> products = await _context.Products.Include(p => p.Category).Select(p => (ProductGet)p).ToListAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductsAsync(ProductPost request)
        {
            Product product = request;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok((ProductGet)product);
        }
    }
}
