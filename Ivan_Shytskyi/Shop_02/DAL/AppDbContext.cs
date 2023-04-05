using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Courier> Сourier { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Storege> Storege { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasIndex(p =>  p.UserName)
                 .IsUnique();
            modelBuilder.Entity<Courier>()
                 .HasIndex(p => p.UserName)
                 .IsUnique();
            modelBuilder.Entity<Admin>()
                 .HasIndex(p => p.UserName)
                 .IsUnique();
            base.OnModelCreating(modelBuilder);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseNpgsql("Server=host.docker.internal;Port=32768;Database=Final_Project;User Id=postgres;Password=postgrespw;")
        //        .LogTo(text => File.AppendAllText("log.txt", text));
        //}
    }
}
