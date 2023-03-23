using Homework34.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;

namespace Homework34.DAL
{
    public class MarketContext : DbContext
    {

        public MarketContext() : base()
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Tag> Tag { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder
                .UseNpgsql("Server=host.docker.internal;Port=32768;Database=Market_2;User Id=postgres;Password=postgrespw;")
                .LogTo(Console.WriteLine);
        }
    }
}

