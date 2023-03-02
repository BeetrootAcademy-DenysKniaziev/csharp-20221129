using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lesson34.Models;

namespace Lesson34.Data
{
    public class Lesson34Context : DbContext
    {
        public Lesson34Context (DbContextOptions<Lesson34Context> options)
            : base(options)
        {
        }

        public DbSet<Lesson34.Models.Product> Product { get; set; } = default!;

        public DbSet<Lesson34.Models.Person> Person { get; set; } = default!;

        public DbSet<Lesson34.Models.Orders> Orders { get; set; } = default!;
    }
}
