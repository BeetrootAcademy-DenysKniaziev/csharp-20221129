using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lesson34.Data;
using System;
using System.Linq;

namespace Lesson34.Models;

public static class SeedDataPeople
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Lesson34Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<Lesson34Context>>()))
        {
            if (context.Person.Any())
            {
                return;   // DB has been seeded
            }
            context.Person.AddRange(
                new Person
                {
                    FullName = "Andriy",
                    Age = 20,
                    Phone = "278-293"
                },
                new Person
                {
                    FullName = "Oleksandr",
                    Age = 18,
                    Phone = "927-182"
                },
                new Person
                {
                    FullName = "Oleksiy",
                    Age = 27,
                    Phone = "672-289"
                },
                new Person
                {
                    FullName = "Petro",
                    Age = 17,
                    Phone = "289-982"
                }
            );
            context.SaveChanges();
        }
    }
}