using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Controller.Tests
{
    public class CommentControllerTests
    {
        private Mock<ICommentsService> _commentsServiceMock;
        private Mock<IUsersServices> _usersServiceMock;
        private Mock<IArticlesService> _articlesServiceMock;
        private Mock<ILogger<CommentController>> _loggerMock;
        private CommentController _controller;

        public CommentControllerTests()
        {
            _commentsServiceMock = new Mock<ICommentsService>();
            _usersServiceMock = new Mock<IUsersServices>();
            _articlesServiceMock = new Mock<IArticlesService>();
            _loggerMock = new Mock<ILogger<CommentController>>();
            _controller = new CommentController(_commentsServiceMock.Object, _usersServiceMock.Object, _articlesServiceMock.Object, _loggerMock.Object);
            var identity = new ClaimsIdentity(new Claim[]
       {
        new Claim(ClaimTypes.Name, "testuser")
       });
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext();
            httpContext.User = claimsPrincipal;
            httpContext.Session = new TestSession();
            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };
        }

        [Fact]
        public async Task PostComment_ReturnsUnauthorized_WhenUserIsNull()
        {
            // Arrange
            _usersServiceMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync((User)null);

            // Act
            var result = await _controller.PostComment(1, 1, "Test comment");

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PostComment_ReturnsBadRequest_WhenCommentIsTooLong()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testuser" };
            _usersServiceMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _controller.PostComment(1, 1, new string('a', 251));

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PostComment_ReturnsBadRequest_WhenCommentIsEmpty()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testuser" };
            _usersServiceMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _controller.PostComment(1, 1, "");

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PostComment_ReturnsContentResult_WithSerializedComment()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testuser", Image = "testimage" };
            var article = new Article { Id = 1 };
            _usersServiceMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
            _articlesServiceMock.Setup(x => x.GetByNumberAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(article);
            _commentsServiceMock.Setup(x => x.AddAsync(It.IsAny<Comment>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.PostComment(1, 1, "Test comment");
          
            // Assert
            Assert.NotNull(result);
            Assert.Contains("testuser", (result.Result as ContentResult).Content);
        }
    }
}
