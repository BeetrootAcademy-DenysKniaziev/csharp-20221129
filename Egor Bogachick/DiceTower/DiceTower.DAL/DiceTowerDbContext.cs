using DiceTower.DAL.DTO;
using Microsoft.EntityFrameworkCore;

namespace DiceTower.DAL
{
    public class DiceTowerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DiceTowerDbContext(DbContextOptions<DiceTowerDbContext> options) : base(options)
        {
        }
    }
}
