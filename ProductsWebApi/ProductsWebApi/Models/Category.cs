﻿namespace ProductsWebApi.Models
{
    public class Category
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;

        public List<Product> Products { get; init; } = [];
    }
}
