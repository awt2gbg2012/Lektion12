using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Lektion12.Data.Entities;

namespace Lektion12.Data.Context
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    public class Lektion12Initializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            // Seed Category data
            var catWatersport = new Category { CategoryID = 1, Name = "Watersport" };
            var catSoccer = new Category { CategoryID = 2, Name = "Soccer" };
            var catChess = new Category { CategoryID = 3, Name = "Chess" };
            var catKayaks = new Category {CategoryID = 4, Name = "Kayaks", ParentID = 1};
            var catSafety = new Category {CategoryID = 5, Name = "Safety Equipment", ParentID = 1};
            var catEquipment = new Category {CategoryID = 6, Name = "Equipment", ParentID = 2};
            var catClothing = new Category {CategoryID = 7, Name = "Clothing", ParentID = 3};
            var catAccessories = new Category { CategoryID = 8, Name = "Accessories", ParentID = 3 };
            var categories = new List<Category>
            {
                catWatersport,
                catSoccer,
                catChess,
                catKayaks,
                catSafety,
                catEquipment,
                catClothing,
                catAccessories
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            // Seed Product data
            var products = new List<Product>
            {
                new Product { ProductID = 1, Name = @"Kayak", Description = @"A boat for one person", Price = 275M, Category = catKayaks },
                new Product { ProductID = 2, Name = @"Lifejacket", Description = @"Protective and fashionable", Price = 48.95M, Category = catSafety},
                new Product { ProductID = 3, Name = @"Soccer ball", Description = @"FIFA-approved size and weight", Price = 19.5M, Category = catEquipment },
                new Product { ProductID = 4, Name = @"Corner flags", Description = @"Give your playing field that professional touch", Price = 34.95M, Category = catEquipment },
                new Product { ProductID = 5, Name = @"Stadium", Description = @"Flat-packed 35,000 seat stadium", Price = 79500M, Category = catEquipment },
                new Product { ProductID = 6, Name = @"Thinking cap", Description = @"Improve your brain efficiency by 75%", Price = 16.0M, Category = catClothing },
                new Product { ProductID = 7, Name = @"Unsteady chair", Description = @"Secretly give your opponent a disadvantage", Price = 29.95M, Category = catAccessories },
                new Product { ProductID = 8, Name = @"Human Chess Board", Description = @"A fun game for the whole family", Price = 75.00M, Category = catAccessories},
                new Product { ProductID = 9, Name = @"Bling-bling King", Description = @"Gold-plated, diamond-studded King", Price = 275M, Category = catAccessories },

            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }
    }
}
