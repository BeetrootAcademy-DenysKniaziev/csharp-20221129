using Lesson29.Classwork.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Lesson29.Classwork
{
    public class ShopDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Person)
                    .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                    .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Server=host.docker.internal;Port=32768;Database=shop_new;User Id=postgres;Password=postgrespw;")
                .LogTo(text => File.AppendAllText("log.txt", text));
        }
    }
}
