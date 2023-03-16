using Microsoft.EntityFrameworkCore;
using System.IO;
using Lesson29.Models;
using Microsoft.Extensions.Configuration;

namespace Lesson29
{
    internal class MyDBContext : DbContext
    {
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(o => o.Genre)
                    .WithMany(p => p.Movies)
                .HasForeignKey(o => o.GenreId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(o => o.AccountType)
                    .WithMany(p => p.Users)
                .HasForeignKey(o => o.AccountTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Server=host.docker.internal;Port=32768;Database=Lesson29;User Id=postgres;Password=postgrespw;")
                .LogTo(text => File.AppendAllText("log.txt", text));
        }
    }
}
