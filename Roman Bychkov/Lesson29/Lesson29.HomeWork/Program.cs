
using Lesson29.HomeWork;
using Lesson29.HomeWork.DTO;
using Microsoft.EntityFrameworkCore;

class Program
{
    async public static Task Main()
    {
        using var db = new FilmCatalogDbContext();
        //var genreMovie = new Genre()
        //{
        //    Name = "Comedy"
        //};
        //await db.Genres.AddAsync(genreMovie);
        //await db.SaveChangesAsync();

        //var production = new Production()
        //{
        //    Name = "WarnerBrothers",
        //    YearOfCreated = DateTime.UtcNow
        //};
        //await db.Productions.AddAsync(production);
        //await db.SaveChangesAsync();
        //var genre = await db.Genres.FirstAsync();
        //var film = new Film()
        //{
        //    Name = "NoTime",
        //    Budget = 250.05m,
        //    Production = db.Productions.First(),
        //};
        //film.Genres.Add(genre);
        //await db.Films.AddAsync(film);
        //await db.SaveChangesAsync();
        //var film = await db.Films.Include(film => film.Genres).FirstOrDefaultAsync();
        //var genreMovie2 = new Genre()
        //{
        //    Name = "Criminal"
        //};
        //await db.Genres.AddAsync(genreMovie2);
        //await db.SaveChangesAsync();
        //film.Genres.Add(genreMovie2);
        //db.Update(film);
        //await db.SaveChangesAsync();
        foreach (var prod in (await db.Productions.Include(prod => prod.Films).FirstOrDefaultAsync()).Films)
        {
            Console.WriteLine(prod);
            //}
           
        }
        var actor = new Actor()
        {
            Name = "Johny",
            LastName = "Depp",
            Birthday = DateTime.UtcNow,
            Gender = 'M'
        };
        actor.Films.Add(await db.Films.FirstOrDefaultAsync());
        await db.Actors.AddAsync(actor);
        await db.SaveChangesAsync();
    }
}