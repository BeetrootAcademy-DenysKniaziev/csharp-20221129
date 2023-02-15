
using Lesson29.HomeWork;
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
        //db.Genres.Add(genreMovie);
        //db.SaveChanges();

        //var production = new Production()
        //{
        //    Name = "WarnerBrothers",
        //    YearOfCreated = DateTime.UtcNow
        //};
        //db.Productions.Add(production);
        //db.SaveChanges();
        //var genre = db.Genres.First();
        //var film = new Film()
        //{
        //    Name = "NoTime",
        //    Budget = 250.05m,
        //    Production = db.Productions.First(),
        //};
        //film.Genres.Add(genre);
        //db.Films.Add(film);
        //db.SaveChanges();
        //var film = db.Films.Include(film=>film.Genres).FirstOrDefault();
        //var genreMovie2 = new Genre()
        //{
        //    Name = "Criminal"
        //};
        //db.Genres.Add(genreMovie2);
        //db.SaveChanges();
        //film.Genres.Add(genreMovie2);
        //db.Update(film);
        //db.SaveChanges();
        foreach (var prod in (await db.Productions.Include(prod => prod.Films).FirstOrDefaultAsync()).Films)
        {
            Console.WriteLine(prod);
        }




    }
}