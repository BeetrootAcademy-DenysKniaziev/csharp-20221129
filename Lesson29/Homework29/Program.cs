using Homework29.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Homework29
{
    //Create FilmCatalog using Entity Framework
    //Declare db context, create migrations, try to query and save data using EF
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var dbContext = new FilmCatalogDBContext();
            dbContext.Database.EnsureCreated();

            //dbContext.Add<Actor>(new Actor { FirstName = "Will", LastName = "Smith"} );
            //dbContext.Add(new Actor { FirstName = "Shoen", LastName = "Conary" });
            //dbContext.Add(new Film { FilmName = "Film1", DateOfProduction = new DateTime(2001, 8, 25) });
            //dbContext.Add(new Film { FilmName = "Film2", DateOfProduction = new DateTime(1998, 3, 14) });
            //dbContext.SaveChanges();

            //dbContext.Add(new Casting { ActorId = 1, FilmId = 1 });
            //dbContext.SaveChanges();

            //dbContext.Add(new Casting { ActorId = 2, FilmId = 1 });
            //dbContext.SaveChanges();

            //SELECT "films"."film_name", "films"."date_of_production", "actors"."first_name", "actors"."last_name"
            //FROM "castings"
            //FULL OUTER JOIN "films" ON "castings"."FilmId" = films.id
            //FULL OUTER JOIN "actors" ON "castings"."ActorId" = actors.id

            //var a = dbContext.Castings.Select(x => new Casting { ActorId = x.ActorId, FilmId = x.FilmId });


            //var query = dbContext.Castings
            //        .OrderBy(o => o.Film.FilmName)
            //        .SelectMany(o => o.Film)
            //        .Distinct()
            //        .Select(i => i.);

            //    var result = query
            //        .ToArray();

            var q = dbContext.Films.Select(g => g.FilmName);// ExecuteSqlCommandAsync("SELECT * FROM films");
            //var k = await dbContext.Films.FirstAsync(x => x.FilmName == "Film1");
            Console.WriteLine(q.Count());

            //foreach (var item in dbContext.Castings.Include(x => x.Film).Include(x => x.Actor))
            //{
            //  Console.WriteLine(item.Actor.FirstName);
            //}
        }
    }
}


//To use .NET Core CLI tools in my "F..diffirent environment"
//< ItemGroup >
//  < PackageReference Include = "Npgsql.EntityFrameworkCore.PostgreSQL" Version = "3.1.4" />
//  < PackageReference Include = "Microsoft.EntityFrameworkCore.Design" Version = "3.1.5" >
//    < IncludeAssets > runtime; build; native; contentfiles; analyzers; buildtransitive </ IncludeAssets >
//    < PrivateAssets > all </ PrivateAssets >
//  </ PackageReference >
//</ ItemGroup >


//dotnet ef migrations add InitialCreate --output-dir InitMigrationTest
// || dotnet ef migrations add InitialCreate
// dotnet ef database update

//!!! Rebuild Solution after each change in connection string ...

//dotnet ef migrations add AddAwardingCompetitiorsTable --output-dir AddAwardingCompetitiorsTableMigration //NameThatShowWhatWasChanged
// Chengae namespace in one of the new generated (2nd migration) .cs from .InitMigrationTest .AddAwardingCompetitiorsTableMigration // Don`t ask
// dotnet ef database update

//dotnet ef migrations add AddHightToActor --output-dir AddHightToActorMigartion
// dotnet ef database update

//"MigrationId"
//"20230219022736_InitialCreate"
//"20230219043225_AddAwardingCompetitiorsTable"
//"20230219052810_AddHightToActor"


