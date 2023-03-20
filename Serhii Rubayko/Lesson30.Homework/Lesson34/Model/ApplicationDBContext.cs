using Microsoft.EntityFrameworkCore;

namespace Lesson34.Model
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<> Persons { get; set; }
    }
}
