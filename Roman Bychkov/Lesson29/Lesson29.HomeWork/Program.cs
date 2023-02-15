
using Lesson29.HomeWork;

class Program
{
    public static void Main()
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
        //film.Genres = new List<Genre> { genre };
        //db.Films.Add(film);
        //db.SaveChanges();
        //db.GenresAndFilms.FirstOrDefault();


    }
}