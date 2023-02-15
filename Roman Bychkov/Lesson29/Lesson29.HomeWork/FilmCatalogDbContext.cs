using Lesson29.HomeWork.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson29.HomeWork
{
    internal class FilmCatalogDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Production> Productions { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<ProductionAndFilm> ProductionAndFilm { get; set; }
     

        public FilmCatalogDbContext()
        {
            //base.Database.EnsureDeleted();
            //base.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=host.docker.internal;Port=32768;User Id=postgres;Password=postgrespw;Database=FilmCatalog");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //here is api
        }
    }
}
