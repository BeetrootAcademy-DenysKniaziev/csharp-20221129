using Lesson_34.DataModel.DTO;
using Microsoft.EntityFrameworkCore;

namespace Lesson_34.DataModel
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Server=host.docker.internal;Port=32768;Database=SHOP;User Id=postgres;Password=postgrespw;")
                .LogTo(text => File.AppendAllText("log.txt", text));
        }
    }
}
