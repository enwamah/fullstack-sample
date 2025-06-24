using ProductsWebApi.Data;
using ProductsWebApi.Models;

namespace ProductsWebApi.Helpers
{
    public static class DatabaseSetup
    {
        public static void AddedDummyData(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var categories = new List<Category>
            {
                new() { Name = "Devices", Description = "Tablets, phones, and other electronics" },
                new() { Name = "Appliances", Description = "Microwaves, refrigerators, and freezers" },
                new() { Name = "Books", Description = "Tragedy, horror, and comedy novels" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var products = new List<Product>
            {
                new()
                {
                    Name = "Laptop",
                    Description = "A generic laptop",
                    Price = 199.99m,
                    CategoryId = categories[0].Id
                },
                new()
                {
                    Name = "Microwave",
                    Description = "A generic microwave",
                    Price = 49.98m,
                    CategoryId = categories[1].Id
                },
                new()
                {
                    Name = "Worm",
                    Description = "An action packed thriller by John McCrae",
                    Price = 0,
                    CategoryId = categories[2].Id
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }

}
