using Lesson_29.Homework.DTO;
using System.Diagnostics.Metrics;


namespace Lesson_29.Homework
{
    public class Program
    {
        static async Task Main()
        {
            await using var dbContext = new MyDbContext();
            dbContext.Database.EnsureCreated();

            var actor1 = new Actor
            {
                FirstName = "Klark",
                LastName = "Kent",
                Age = 41
            };
            var actor2 = new Actor
            {
                FirstName = "Anna",
                LastName = "de Armas",
                Age = 33
            };
            dbContext.Actors.AddAsync(actor1);
            dbContext.Actors.AddAsync(actor2);
            var producer1 = new Producer
            {
                FirstName = "Dave",
                LastName = "Filoni",
                Age = 47
            };
            dbContext.Producers.AddAsync(producer1);

            var studio1 = new Studio
            {
                Name = "Disnay"
            };
            dbContext.Studios.AddAsync(studio1);

            var listactor = new ListActor
            {
                Actors = new List<Actor> { actor1, actor2 }
            };
            dbContext.ListActor.AddAsync(listactor);

            var movie1 = dbContext.Movies.AddAsync(new Movie
            {
                Name = "Asoka",
                Genre = "Fantasy",
                ReleaseDate = new DateOnly(2023,9,15),
                Rating = 8,
                Country = "USA",
                Producer = producer1,
                ListActor = listactor,
                Studio = studio1
            });

            await dbContext.SaveChangesAsync();

            foreach (var actor in dbContext.Actors)
            {
                Console.WriteLine(actor);
            }
        }
    }
}