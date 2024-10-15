using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var basePath = Directory.GetCurrentDirectory();
            if (!basePath.Contains("BusinessObjects"))
            {
                basePath = Path.Combine(basePath, "..", "BusinessObjects");
            }

            var builder = new ConfigurationBuilder()
                              .SetBasePath(basePath)
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Confections" },
                new Category { CategoryId = 4, CategoryName = "Dairy Products" },
                new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
                new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
                new Category { CategoryId = 7, CategoryName = "Produce" },
                new Category { CategoryId = 8, CategoryName = "Seafood" }
               );
            optionsBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Soda", CategoryId = 1, UnitsInStock = 11, UnitPrice = 10000 },
                new Product { ProductId = 2, ProductName = "Yellow mustard", CategoryId = 2, UnitsInStock = 21, UnitPrice = 20000 },
                new Product { ProductId = 3, ProductName = "Chocolate layer cake", CategoryId = 3, UnitsInStock = 31, UnitPrice = 30000 },
                new Product { ProductId = 4, ProductName = "Cheese", CategoryId = 4, UnitsInStock = 14, UnitPrice = 40000 },
                new Product { ProductId = 5, ProductName = "Cereal", CategoryId = 5, UnitsInStock = 15, UnitPrice = 15000 },
                new Product { ProductId = 6, ProductName = "Chicken", CategoryId = 6, UnitsInStock = 24, UnitPrice = 24000 },
                new Product { ProductId = 7, ProductName = "Melon", CategoryId = 7, UnitsInStock = 31, UnitPrice = 34000 },
                new Product { ProductId = 8, ProductName = "Crab", CategoryId = 8, UnitsInStock = 26, UnitPrice = 45000 }
               );
        }
    }
}
