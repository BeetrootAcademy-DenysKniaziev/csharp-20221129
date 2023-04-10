

using LearningSystem.WEB.Logger;

namespace LearningSystem.Controller.Tests
{
    public class LikeControllerTests
    {
        private readonly Mock<ILikeArticleService> _likeServiceMock;
        private readonly Mock<IUsersServices> _usersServiceMock;
        private readonly Mock<IArticlesService> _articlesServiceMock;
        private readonly Mock<ILogger<LikeController>> _loggerMock;

        public LikeControllerTests()
        {
            _likeServiceMock = new Mock<ILikeArticleService>();
            _usersServiceMock = new Mock<IUsersServices>();
            _articlesServiceMock = new Mock<IArticlesService>();
            _loggerMock = new Mock<ILogger<LikeController>>();
        }

        [Fact]
        public async Task PostLike_WhenUserIsNull_ShouldReturnUnauthorized()
        {
            // Arrange
            var controller = new LikeController(_likeServiceMock.Object, _usersServiceMock.Object, _articlesServiceMock.Object, _loggerMock.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = null }
            };

            // Act
            var result = await controller.PostLike(1, 1);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task PostLike_WhenArticleLikeExists_ShouldDeleteLikeAndReturnNotFound()
        {
            // Arrange
            var user = new User() { Id = 1, UserName = "TestUser" };
            var article = new Article() { Id = 1, Number = 1, CourseId = 1 };
            var articleLike = new LikeArticle() { Id = 1, UserId = user.Id, ArticleId = article.Id };

            _usersServiceMock.Setup(s => s.GetByName(user.UserName)).ReturnsAsync(user);
            _articlesServiceMock.Setup(s => s.GetByNumberAsync(article.Number, article.CourseId)).ReturnsAsync(article);
            _likeServiceMock.Setup(s => s.LikeExistInArticle(article, user)).ReturnsAsync(articleLike);

            var controller = new LikeController(_likeServiceMock.Object, _usersServiceMock.Object, _articlesServiceMock.Object, _loggerMock.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.UserName) }, "TestAuthentication")) }
            };

            // Act
            var result = await controller.PostLike(article.Number, article.CourseId);

            // Assert
            _likeServiceMock.Verify(s => s.DeleteAsync(articleLike), Times.Once);
            _loggerMock.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals(o.ToString(), $"{user.UserName} deleted like to course {article.CourseId} lesson {article.Number}. code-{RepoLogEvents.UserUnLike}")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
            Assert.IsType<NotFoundObjectResult>(result);
            Assert.False((bool)((NotFoundObjectResult)result).Value);
        }
        [Fact]
        public async Task PostLike_WhenArticleLikeDoesNotExist_ShouldAddLikeAndReturnOk()
        {
            // Arrange
            var user = new User() { Id = 1, UserName = "TestUser" };
            var article = new Article() { Id = 1, Number = 1, CourseId = 1 };

            _articlesServiceMock.Setup(s => s.GetByNumberAsync(article.Number, article.CourseId)).ReturnsAsync(article);
            _likeServiceMock.Setup(s => s.LikeExistInArticle(article, user)).ReturnsAsync((LikeArticle)null);
            _usersServiceMock.Setup(s=>s.GetByName(user.UserName)).ReturnsAsync(user);

            var controller = new LikeController(_likeServiceMock.Object, _usersServiceMock.Object, _articlesServiceMock.Object, _loggerMock.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.UserName) }, "TestAuthentication")) }
            };

            // Act
            var result = await controller.PostLike(article.Number, article.CourseId);

            // Assert
            _likeServiceMock.Verify(s => s.AddAsync(It.Is<LikeArticle>(l => l.UserId == user.Id && l.ArticleId == article.Id)), Times.Once);
            _loggerMock.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals(o.ToString(), $"{user.UserName} added like to course {article.CourseId} lesson {article.Number}. code-{RepoLogEvents.UserLike}")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
            Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)((OkObjectResult)result).Value);
        }
    }
}
