﻿using Microsoft.EntityFrameworkCore;
using ProductsWebApi.Models;

namespace ProductsWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
