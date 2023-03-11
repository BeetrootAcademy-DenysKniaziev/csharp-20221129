using Lesson_29.Homework.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_29.Homework
{
    public class MyDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<ListActor> ListActor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Server=host.docker.internal;Port=32768;Database=Rating_Films;User Id=postgres;Password=postgrespw;")
                //.LogTo(text => File.AppendAllText("log.txt", text));
                .LogTo(Console.WriteLine);
        }
    }
}
