namespace ProductsWebApi.DTOs.Product
{
    public class ProductGet
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public int CategoryId { get; init; }

        public static explicit operator ProductGet(Models.Product product)
        {
            return new ProductGet
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }
    }
}
