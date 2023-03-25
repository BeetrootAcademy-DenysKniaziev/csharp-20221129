using LearningSystem.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LikeArticle> LikeArticles { get; set; }
        public DbSet<LikeComment> LikeComments { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //    .UseNpgsql("Server=host.docker.internal;Port=32768;Database=learning_system;User Id=postgres;Password=postgrespw;");
            //.LogTo(text => File.AppendAllText("log.txt", text));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p => p.UserName)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(p => p.Email)
                .IsUnique();

            modelBuilder.Entity<Article>()
            .HasIndex(l => new { l.CourseId, l.Number })
            .IsUnique();
        }
    }
}