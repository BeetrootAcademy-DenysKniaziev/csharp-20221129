using Lesson29.Classwork.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson29.Classwork
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using var dbContext = new ShopDBContext();
            dbContext.Database.EnsureCreated();

            //var person = new Person
            //{
            //    FirstName = "Paul",
            //    LastName = "Kent",
            //    Age = 20,
            //    Gender = "M",
            //    Address = "Some Adress"
            //};

            //await dbContext.Persons.AddAsync(person);

            //var product = new Product
            //{
            //    Name = "Flower",
            //    Description = "Nice Flower",
            //    Price = 70,
            //    DiscountedPrice = 69.99m
            //};

            //await dbContext.Products.AddAsync(product);

            //await dbContext.Orders.AddAsync(new Order
            //{
            //    Person = person,
            //    Product = product,
            //    OrderTime = System.DateTime.UtcNow
            //});

            //await dbContext.SaveChangesAsync();

            //foreach (var pe in dbContext.Persons)
            //{
            //    System.Console.WriteLine(pe);
            //}

            //foreach (var pr in dbContext.Products)
            //{
            //    System.Console.WriteLine(pr);
            //} 

            var person = await dbContext.Persons.FirstAsync(x => x.FirstName == "Paul" && x.Gender == "M"));
            person.Age = 30;
            dbContext.Persons.Update(person);
            await dbContext.SaveChangesAsync();

            foreach (var or in dbContext.Orders.Include(x => x.Person).Include(x => x.Product))
            {
                System.Console.WriteLine($"{or.Person.FirstName}({or.Person.Age}) {or.Product.Name} {or.OrderTime}");
            }

            foreach (var pe in dbContext.Persons.Include(x => x.Orders))
            {
                
            }
        }

    }
}