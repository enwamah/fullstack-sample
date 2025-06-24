using System.ComponentModel.DataAnnotations;

namespace ProductsWebApi.DTOs.Product
{
    public class ProductPost
    {
        [Required]
        [StringLength(100)]
        public string Name { get; init; } = string.Empty;
        [Required]
        [StringLength(600)]
        public string Description { get; init; } = string.Empty;
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; init; }
        [Required]
        public int CategoryId { get; init; }

        public static implicit operator Models.Product(ProductPost product)
        {
            return new Models.Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }
    }
}
