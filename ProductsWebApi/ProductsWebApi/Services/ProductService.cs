using Microsoft.EntityFrameworkCore;
using ProductsWebApi.Data;
using ProductsWebApi.DTOs.Product;
using ProductsWebApi.Models;

namespace ProductsWebApi.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductGet>> GetAllAsync()
        {
            return await _context.Products
                .Select(p => (ProductGet)p)
                .ToListAsync();
        }

        public async Task<ProductGet?> CreateAsync(ProductPost request)
        {
            Product product = request;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return (ProductGet)product;
        }
    }
}
