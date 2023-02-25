using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lesson34.Data;
using System;
using System.Linq;

namespace Lesson34.Models;

public static class SeedDataProducts
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Lesson34Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<Lesson34Context>>()))
        {
            if (context.Product.Any())
            {
                return;   // DB has been seeded
            }
            context.Product.AddRange(
                new Product
                {
                    Title = "Banana",
                    Description = "Yellow",
                    Price = 0.5
                },
                new Product
                {
                    Title = "Apple",
                    Description = "Without worms",
                    Price = 0.2
                },
                new Product
                {
                    Title = "Pinapple",
                    Description = "Big",
                    Price = 3.2
                },
                new Product
                {
                    Title = "Bread",
                    Description = "Cutted",
                    Price = 0.8
                }
            );
            context.SaveChanges();
        }
    }
}