using Microsoft.EntityFrameworkCore;

namespace Teste___Webapi.Models;

static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Category 1" },
            new Category { Id = 2, Name = "Category 2" },
            new Category { Id = 3, Name = "Category 3" },
            new Category { Id = 4, Name = "Category 4" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Sku = "P1", Name = "Product 1", Description = "Description 1", Price = 100m, IsAvailable = true, CategoryId = 1 },
            new Product { Id = 2, Sku = "P2", Name = "Product 2", Description = "Description 2", Price = 200m, IsAvailable = true, CategoryId = 1 },
            new Product { Id = 3, Sku = "P3", Name = "Product 3", Description = "Description 3", Price = 100m, IsAvailable = true, CategoryId = 1 },
            new Product { Id = 4, Sku = "P4", Name = "Product 4", Description = "Description 4", Price = 100m, IsAvailable = true, CategoryId = 2 },
            new Product { Id = 5, Sku = "P5", Name = "Product 5", Description = "Description 5", Price = 100m, IsAvailable = true, CategoryId = 2 },
            new Product { Id = 6, Sku = "P6", Name = "Product 6", Description = "Description 6", Price = 100m, IsAvailable = true, CategoryId = 2 },
            new Product { Id = 7, Sku = "P7", Name = "Product 7", Description = "Description 7", Price = 100m, IsAvailable = true, CategoryId = 3 },
            new Product { Id = 8, Sku = "P8", Name = "Product 8", Description = "Description 8", Price = 100m, IsAvailable = true, CategoryId = 3 },
            new Product { Id = 9, Sku = "P9", Name = "Product 9", Description = "Description 9", Price = 100m, IsAvailable = true, CategoryId = 3 },
            new Product { Id = 10, Sku = "P10", Name = "Product 10", Description = "Description 10", Price = 100m, IsAvailable = true, CategoryId = 4 },
            new Product { Id = 11, Sku = "P11", Name = "Product 11", Description = "Description 11", Price = 100m, IsAvailable = true, CategoryId = 4 },
            new Product { Id = 12, Sku = "P12", Name = "Product 12", Description = "Description 12", Price = 100m, IsAvailable = true, CategoryId = 4 }
        );
    }
}
