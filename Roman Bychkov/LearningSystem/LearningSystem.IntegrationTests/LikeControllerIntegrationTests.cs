using LearningSystem.Contracts;
using LearningSystem.DAL;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace LearningSystem.IntegrationTests
{
    public class LikeControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _dbContext;

        public LikeControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            factory.Services.GetService<IMemoryCache>().Dispose();
            _client = factory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:7163");
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql("Server=host.docker.internal;Port=32768;Database=learning_system_test;User Id=postgres;Password=postgrespw;")
                .Options;
            _dbContext = new ApplicationDbContext(options);
            _dbContext.Database.EnsureCreated();
            //SeedTestData(_dbContext);
        }

        [Fact]
        public async Task PostLike_WhenLikeDoesNotExist_ReturnsOkResult()
        {
           
            // Act
            var response = await _client.PostAsJsonAsync(new Uri("https://localhost:7163/api/like/post"), new Like(1, 2));


            // Assert
            response.EnsureSuccessStatusCode();
            var like = await _dbContext.LikeArticles.FindAsync(1, 2);
            Assert.NotNull(like);
        }

        [Fact]
        public async Task PostLike_WhenLikeAlreadyExists_ReturnsConflictResult()
        {
            // Arrange
            var like = new Like(1, 2);

            _dbContext.LikeArticles.Add(new LikeArticle()
            { 
                ArticleId = 1,
                UserId = 1
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var response = await _client.PostAsJsonAsync("/api/like/post", new Like(1, 2));

            // Assert
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }

        //private void SeedTestData(ApplicationDbContext dbContext)
        //{
        //    var user1 = new User { UserName = "John", Password = "qwe123", Email = "r@gmail.com" };
        //    var user2 = new User { UserName = "Jane", Password = "qwe124", Email = "a@gmail.com" };
        //    var post1 = new Post(2, "Post 1");
        //    dbContext.Users.AddRange(user1, user2);
        //    dbContext.Posts.Add(post1);
        //    dbContext.SaveChanges();
        //}
    }
}
