using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext dbContext = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate(); //create db if it not exist using migrations

            if(!dbContext.Products.Any())
            {
                // insert products
                dbContext.Products.AddRange(
                    new Product { Name = "Kayak", Description = "A boat for one person", Category = "Watersports", Price = 275 },
                    new Product { Name = "LifeJacket", Description = "Protective and fashionable", Category = "Watersports", Price = 49.95M },
                    new Product { Name = "Soccer Ball", Description = "Football soccer ball", Category = "Soccer", Price = 19.50M },
                    new Product { Name = "Corner Flags", Description = "Flags for soccer fields", Category = "Soccer", Price = 34.95M },
                    new Product { Name = "Stadium", Description = "Soccer/football playing field", Category = "Soccer", Price = 79500 },
                    new Product { Name = "Thinking Cap", Description = "Improve brain efficiency by 75%", Category = "Chess", Price = 16 },
                    new Product { Name = "Unsteady Chair", Description = "Funny chair", Category = "Chess", Price = 29.95M },
                    new Product { Name = "Human chess board", Description = "A fun game", Category = "Chess", Price = 75 },
                    new Product { Name = "Bling king", Description = "Gold plated for rappers", Category = "Chess", Price = 1200 }
                );

                dbContext.SaveChanges();
            }
        }
    }
}
