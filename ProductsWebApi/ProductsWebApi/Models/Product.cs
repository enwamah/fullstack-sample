using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsWebApi.Models
{
    public class Product
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; init; }
        public int CategoryId { get; init; }

        public Category? Category { get; init; }
    }
}
