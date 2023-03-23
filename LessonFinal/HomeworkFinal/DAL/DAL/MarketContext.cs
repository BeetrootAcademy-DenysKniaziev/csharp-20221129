using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Options;
//using System.IO;

namespace ExchangeMarket.DAL 
{
    public class MarketContext : DbContext
    {

        public MarketContext() : base()
        {
        }

        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        { }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Tag> Tag { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Tut treba zrobyty perevirku chy zminyvsya fag "Modifaied" v (zminy v bazi z inshyh sessii) (Yugo tez zrobyty i peredavaty vidpovidno tablyci (People, Orders...)) Yakscho false... 
            // Pracuvaty z listom obektiv i ne ity v bazu???

            var DefoultConnection = optionsBuilder
                .UseNpgsql("Server=host.docker.internal;Port=32768;Database=Market_8;User Id=postgres;Password=postgrespw;")
                .LogTo(Console.WriteLine);

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();

        //        var connectionString = config.GetConnectionString("DefaultConnection");

        //        optionsBuilder.UseNpgsql(connectionString)
        //            .LogTo(Console.WriteLine);
        //    }
        //}
    }
}

