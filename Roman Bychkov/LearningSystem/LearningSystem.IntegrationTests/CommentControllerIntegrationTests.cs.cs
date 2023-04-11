using LearningSystem.BLL.Interfaces;
using LearningSystem.Contracts;
using LearningSystem.DAL;
using LearningSystem.WEB.ValidationModels;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearningSystem.IntegrationTests
{
    public class CommentControllerIntegrationTests : IClassFixture<LearningSystemWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _dbContext;
        private IUsersServices _usersServices;

        public CommentControllerIntegrationTests(LearningSystemWebApplicationFactory<Program> factory)
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
        private async Task Login(HttpClient client)
        {
            var testUser = new LoginModel { UserName = "RomanBychkov", Password = "Qq1" };
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(testUser.UserName), "UserName");
            form.Add(new StringContent(testUser.Password), "Password");
            var response = await _client.PostAsync("account/login", form);
        }

        [Fact]
        public async Task PostComment_WhenArticleDoesNotExist_ReturnsBadNotFound()
        {

            // Arrange

            var comment = new Comment(1, 51);

            // Act
            await Login(_client);

            var responce = await _client.PostAsJsonAsync("/api/comment/PostComment?articleNumber=" + comment.articleNumber + "&courseId=" + comment.courseId + "&comment=" + "ContentComment", comment);
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, responce.StatusCode);
        }
        [Fact]
        public async Task PostComment_WhenLikeDoesNotExist_ReturnsOkResult()
        {

            // Arrange

            var comment = new Comment(1, 1);

            // Act
            await Login(_client);


            var responce = await _client.PostAsJsonAsync("/api/comment/PostComment?articleNumber=" + comment.articleNumber + "&courseId=" + comment.courseId + "&comment=" + "ContentComment", comment);
            // Assert
            Assert.Equal(HttpStatusCode.OK, responce.StatusCode);
        }

        [Fact]
        public async Task PostComment_WhenCommentLongerThan250characters_ReturnsBadRequestResult()
        {
            // Arrange

            var comment = new Comment(1, 1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 251; i++)
                sb.Append("a");

            // Act
            await Login(_client);

            var responce = await _client.PostAsJsonAsync("/api/comment/PostComment?articleNumber=" + comment.articleNumber + "&courseId=" + comment.courseId + "&comment=" + sb.ToString(), comment);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, responce.StatusCode);
        }
        [Fact]
        public async Task PostComment_WhenUserIsUntheraized_ReturnsUntheraized()
        {
            // Arrange

            var comment = new Comment(1, 1);

            // Act

            var responce = await _client.PostAsJsonAsync("/api/comment/PostComment?articleNumber=" + comment.articleNumber + "&courseId=" + comment.courseId + "&comment=" + "ContentComment", comment);
            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, responce.StatusCode);
        }

        private async void SeedTestData(ApplicationDbContext dbContext)
        {

            var user1 = new User { UserName = "RomanBychkov", Password = "Qq1", Email = "r@gmail.com" };
            _usersServices.AddAsync(user1).Wait();
            var course = new Course { Content = "none", CourseName = "test1", ImagePath = "-", Description = "None0", UserId = user1.Id };
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            var article = new Article { Content = "none", ArticleName = "Lesson1", CourseId = course.Id, Number = 1 };
            dbContext.Articles.Add(article);
            dbContext.SaveChanges();
        }
    }
    public record Comment(int courseId, int articleNumber);
    public record Login(string UserName, string Password);
}
