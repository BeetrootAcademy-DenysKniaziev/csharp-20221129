using LearningSystem.BLL.Interfaces;
using LearningSystem.Contracts;
using LearningSystem.DAL;
using LearningSystem.WEB.ValidationModels;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace LearningSystem.IntegrationTests
{
    public class LikeControllerIntegrationTests : IClassFixture<LearningSystemWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _dbContext;
        private IUsersServices _usersServices;

        public LikeControllerIntegrationTests(LearningSystemWebApplicationFactory<Program> factory)
        {
            using var scope = factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            _dbContext = scopedServices.GetRequiredService<ApplicationDbContext>();
            _usersServices = scopedServices.GetRequiredService<IUsersServices>();
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _client = factory.CreateClient();
            SeedTestData(_dbContext);
        }
        private async void Login(HttpClient client)
        {
            var testUser = new LoginModel { UserName = "RomanBychkov", Password = "Qq1" };
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(testUser.UserName), "UserName");
            form.Add(new StringContent(testUser.Password), "Password");
            var response = await _client.PostAsync("account/login", form);
        }

        [Fact]
        public async Task PostLike_WhenArticleDoesNotExist_ReturnsBadRequestResult()
        {

            // Arrange
            var testUser = new LoginModel { UserName = "RomanBychkov", Password = "Qq1" };
            var like = new Like(1, 51);

            // Act
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(testUser.UserName), "UserName");
            form.Add(new StringContent(testUser.Password), "Password");
            var response = await _client.PostAsync("account/login", form);
            var likeResponse = await _client.PostAsJsonAsync("/api/like/PostLike?articleNumber=" + like.articleNumber + "&courseId=" + like.courseId, like);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, likeResponse.StatusCode);
        }
        [Fact]
        public async Task PostLike_WhenLikeDoesNotExist_ReturnsOkResult()
        {

            // Arrange
            var testUser = new LoginModel { UserName = "RomanBychkov", Password = "Qq1" };
            var like = new Like(1, 1);

            // Act
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(testUser.UserName), "UserName");
            form.Add(new StringContent(testUser.Password), "Password");
            var response = await _client.PostAsync("account/login", form);
            var likeResponse = await _client.PostAsJsonAsync("/api/like/PostLike?articleNumber=" + like.articleNumber + "&courseId=" + like.courseId, like);
            // Assert
            Assert.Equal(HttpStatusCode.OK, likeResponse.StatusCode);
        }

        [Fact]
        public async Task PostLike_WhenLikeAlreadyExists_ReturnsNotFoundResult()
        {
            // Arrange
            var testUser = new LoginModel { UserName = "RomanBychkov", Password = "Qq1" };
            var like = new Like(1, 1);

            // Act
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(testUser.UserName), "UserName");
            form.Add(new StringContent(testUser.Password), "Password");
            var response = await _client.PostAsync("account/login", form);
            var likeResponse = await _client.PostAsJsonAsync("/api/like/PostLike?articleNumber=" + like.articleNumber + "&courseId=" + like.courseId, like);
            likeResponse = await _client.PostAsJsonAsync("/api/like/PostLike?articleNumber=" + like.articleNumber + "&courseId=" + like.courseId, like);
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, likeResponse.StatusCode);
        }
        [Fact]
        public async Task PostLike_WhenUserIsUntheraized_ReturnsUntheraized()
        {
            // Arrange
            var like = new Like(1, 1);

            // Act
            var likeResponse = await _client.PostAsJsonAsync("/api/like/PostLike?articleNumber=" + like.articleNumber + "&courseId=" + like.courseId, like);
            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, likeResponse.StatusCode);
        }

        private async void SeedTestData(ApplicationDbContext dbContext)
        {

            var user1 = new User { UserName = "RomanBychkov", Password = "Qq1", Email = "r@gmail.com" };

            //var form = new MultipartFormDataContent();
            //form.Add(new StringContent(user1.UserName), "UserName");
            //form.Add(new StringContent(user1.Password), "Password");
            //form.Add(new StringContent(user1.Password), "ConfirmPassword");
            //form.Add(new StringContent(user1.Email), "Email");

            //var response = await _client.PostAsync("account/registration", form);
            //var user = _dbContext.Users.Find(user1);

            _usersServices.AddAsync(user1).Wait();
            var course = new Course { Content = "none", CourseName = "test1", ImagePath = "-", Description = "None0", UserId = user1.Id };
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            var article = new Article { Content = "none", ArticleName = "Lesson1", CourseId = course.Id, Number = 1 };
            dbContext.Articles.Add(article);
            dbContext.SaveChanges();
        }
    }
    public record Like(int courseId, int articleNumber);
    public record Login(string UserName, string Password);
}
