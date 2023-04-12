using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.Contracts.LessonsStructs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeepLearn.DAL.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<TheoryBlock> TheoryBlocks { get; set; }
        public DbSet<TestBlock> TestBlocks { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(
                    "Server=host.docker.internal;Port=32768;Database=DeepLearnDB;User Id=postgres;Password=postgrespw;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new {l.LoginProvider, l.ProviderKey});

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Modules)
                .WithOne(m => m.Course)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Module>()
                .HasMany(m => m.Lessons)
                .WithOne(l => l.Module)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.TheoryBlocks)
                .WithOne(tb => tb.Lesson)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TheoryBlock>()
                .HasOne(tb => tb.TestBlock)
                .WithOne(tb => tb.TheoryBlock)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TestBlock>()
                .HasMany(l => l.Answers)
                .WithOne(tb => tb.TestBlock)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
