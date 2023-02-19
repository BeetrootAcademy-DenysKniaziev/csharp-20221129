using Homework29.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework29
{
    public class FilmCatalogDBContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Awarding> Awardings { get; set; }
        public DbSet<Casting> Castings { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<AwardingCompetitiors> awardingCompetitiors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder
                .UseNpgsql("Server=host.docker.internal;Port=32768;Database=film_catalog;User Id=postgres;Password=postgrespw;");
                //.LogTo(Console.WriteLine);
        }


    }

}
