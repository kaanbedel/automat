using Automat.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Automat.Persistence.Seed
{
    public static class SeedExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {

            builder.Entity<Category>().HasData(
             new Category { Id = 1, CategoryType = CategoryType.Drink, Name = "İçecek", InsertDate = DateTime.Now, InsertUserId = 1 },
             new Category { Id = 2, CategoryType = CategoryType.Food, Name = "Yiyecek", InsertDate = DateTime.Now, InsertUserId = 1 },
             new Category { Id = 3, CategoryType = CategoryType.HotDrink, Name = "Sıcak İçecek", InsertDate = DateTime.Now, InsertUserId = 1 }
                );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, ProductCode = 100, Name = "Su", Quantity = 10, Price = 1, InsertDate = DateTime.Now, InsertUserId = 1 },
                new Product { Id = 2, CategoryId = 1, ProductCode = 200, Name = "Meyve Suyu", Quantity = 10, Price = 2, InsertDate = DateTime.Now, InsertUserId = 1 },
                new Product { Id = 3, CategoryId = 1, ProductCode = 300, Name = "Cola", Quantity = 10, Price = 3, InsertDate = DateTime.Now, InsertUserId = 1 },
                new Product { Id = 4, CategoryId = 3, ProductCode = 400, Name = "Çay", Quantity = 20, Price = 4, InsertDate = DateTime.Now, InsertUserId = 1 },
                new Product { Id = 5, CategoryId = 3, ProductCode = 500, Name = "Kahve", Quantity = 20, Price = 5, InsertDate = DateTime.Now, InsertUserId = 1 },

                new Product { Id = 6, CategoryId = 2, ProductCode = 1000, Name = "Et", Quantity = 5, Price = 20, InsertDate = DateTime.Now, InsertUserId = 1 },
                new Product { Id = 7, CategoryId = 2, ProductCode = 2000, Name = "Balık", Quantity = 5, Price = 15, InsertDate = DateTime.Now, InsertUserId = 1 },
                new Product { Id = 8, CategoryId = 2, ProductCode = 3000, Name = "Sandviç", Quantity = 5, Price = 10, InsertDate = DateTime.Now, InsertUserId = 1 }

                );
        }
    }
}
