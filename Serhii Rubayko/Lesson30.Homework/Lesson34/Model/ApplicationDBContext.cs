
using Microsoft.EntityFrameworkCore;

namespace Lesson34.Model
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
