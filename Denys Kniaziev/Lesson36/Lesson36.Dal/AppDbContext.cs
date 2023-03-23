using Lesson36.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Lesson36.Dal
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<User> Users { get; set; }

        public AppDbContext() : base()
        {  
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p => p.UserName)
                .IsUnique();
        }
    }
}
