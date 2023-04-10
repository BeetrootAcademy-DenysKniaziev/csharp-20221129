//using LearningSystem.Contracts;
//using LearningSystem.DAL;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System.Linq;

//namespace LearningSystem.IntegrationTests
//{
//    public class LearningSystemWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
//    {
//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices(services =>
//            {
//                // Remove the app's ApplicationDbContext registration.
//                var descriptor = services.SingleOrDefault(
//                    d => d.ServiceType ==
//                        typeof(DbContextOptions<ApplicationDbContext>));

//                if (descriptor != null)
//                {
//                    services.Remove(descriptor);
//                }

//                // Add a database context using an in-memory database for testing.
//                services.AddDbContext<ApplicationDbContext>(options =>
//                {
//                    options.UseNpgsql("Server=host.docker.internal;Port=32768;Database=learning_system_test;User Id=postgres;Password=postgrespw;");
//                });

//                // Build the service provider.
//                var sp = services.BuildServiceProvider();

//                // Create a scope to obtain a reference to the database
//                // context (ApplicationDbContext).
//                using var scope = sp.CreateScope();
//                var scopedServices = scope.ServiceProvider;
//                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

//                // Ensure the database is created.
//                db.Database.EnsureCreated();

//                // Seed the database with test data.
//                //SeedTestData(db);
//            });
//        }

//        //private void SeedTestData(ApplicationDbContext dbContext)
//        //{
//        //    var user1 = new User { UserName = "John", Password="qwe123", Email="r@gmail.com" };
//        //    var user2 = new User { UserName = "Jane", Password = "qwe124", Email = "a@gmail.com" };
//        //    var course = new Course
//        //    {
//        //        UserId = 1,
//        //        ImagePath = "-",
//        //        Content = "2",
//        //        CourseName = "testcourse",
//        //        Description = "desc"
//        //    };
//        //    var post1 = new Post(1, "Post 1");

//        //    dbContext.Users.AddRange(user1, user2);
//        //    dbContext.Posts.Add(post1);
//        //    dbContext.SaveChanges();
//        //}
//    }
  
//}