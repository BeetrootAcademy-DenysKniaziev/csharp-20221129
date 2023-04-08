

namespace LearningSystem.Controller.Tests
{
    public class CourseControllerTests
    {
        private readonly Mock<ILogger<CourseController>> _loggerMock;
        private readonly Mock<ICoursesService> _coursesServiceMock;
        private readonly Mock<IUsersServices> _usersServiceMock;
        private readonly Mock<ILikeArticleService> _arcticlesLikeServiceMock;
        private readonly Mock<IArticlesService> _arcticlesServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CourseController _controller;

        public CourseControllerTests()
        {
            _loggerMock = new Mock<ILogger<CourseController>>();
            _coursesServiceMock = new Mock<ICoursesService>();
            _usersServiceMock = new Mock<IUsersServices>();
            _arcticlesLikeServiceMock = new Mock<ILikeArticleService>();
            _arcticlesServiceMock = new Mock<IArticlesService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new CourseController(
                _loggerMock.Object,
                _coursesServiceMock.Object,
                _usersServiceMock.Object,
                _arcticlesLikeServiceMock.Object,
                _arcticlesServiceMock.Object,
                _mapperMock.Object);
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
        public async Task Lesson_ReturnsViewWithCorrectModel()
        {
            // Arrange
            int id = 1;
            var model = new Course { Id = id };
            _coursesServiceMock.Setup(s => s.GetByIdUserArticleIncludesAsync(id)).ReturnsAsync(model);

            // Act
            var result = await _controller.Lesson(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var resultModel = Assert.IsAssignableFrom<Course>(viewResult.ViewData.Model);
            Assert.Equal(model, resultModel);
        }

        [Fact]
        public async Task Lesson_ReturnsViewWithLikedFlagWhenUserLikesArticle()
        {
            // Arrange
            int id = 1;
            byte number = 2;
            var user = new User();
            var article = new Article { Id = 1, Number = number, CourseId = id };
            _usersServiceMock.Setup(s => s.GetValueBy—onditionAsync(It.IsAny<Func<User, string>>(), It.IsAny<string>())).ReturnsAsync(user);
            _arcticlesServiceMock.Setup(s => s.GetByNumberAsync(number, id)).ReturnsAsync(article);
            _arcticlesLikeServiceMock.Setup(s => s.LikeExistInArticle(article, user)).ReturnsAsync(new LikeArticle());

            // Act
            var result = await _controller.Lesson(id, number);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result) as ViewResult;
            Assert.Contains("liked", viewResult.ViewData.Values);

        }

        [Fact]
        public async Task Workshop_ReturnsRedirectToLoginWhenUserIsNotAuthenticated()
        {
            // Arrange

            // Act
            var result = await _controller.Workshop();

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Account", redirectResult.ControllerName);
            Assert.Equal("Login", redirectResult.ActionName);
        }
        [Fact]
        public async Task Lesson_ReturnsView()
        {
            // Arrange
            int courseId = 1;
            byte articleNumber = 2;
            _coursesServiceMock.Setup(s => s.GetByIdAllIncludesAsync(courseId)).ReturnsAsync(new Course());

            // Act
            var result = await _controller.Lesson(courseId, articleNumber);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }

        [Fact]
        public async Task Lesson_SetsActiveViewBag()
        {
            // Arrange
            int courseId = 1;
            byte articleNumber = 2;
            _coursesServiceMock.Setup(s => s.GetByIdAllIncludesAsync(courseId)).ReturnsAsync(new Course());

            // Act
            var result = await _controller.Lesson(courseId, articleNumber);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("courses", viewResult.ViewData["active"]);
        }

        [Fact]
        public async Task Lesson_SetsNumberViewBag()
        {
            // Arrange
            int courseId = 1;
            byte articleNumber = 2;
            _coursesServiceMock.Setup(s => s.GetByIdAllIncludesAsync(courseId)).ReturnsAsync(new Course());

            // Act
            var result = await _controller.Lesson(courseId, articleNumber);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(articleNumber, (int)viewResult.ViewData["number"]);
        }

        [Fact]
        public async Task Lesson_DoesNotSetLikedViewBag_WhenUserHasNotLikedArticle()
        {
            // Arrange
            int courseId = 1;
            byte articleNumber = 2;
            var user = new User();
            var article = new Article { Id = 1, Number = articleNumber, CourseId = courseId };
            _coursesServiceMock.Setup(s => s.GetByIdAllIncludesAsync(courseId)).ReturnsAsync(new Course());
            _usersServiceMock.Setup(s => s.GetValueBy—onditionAsync(It.IsAny<Func<User, string>>(), It.IsAny<string>())).ReturnsAsync(user);
            _arcticlesServiceMock.Setup(s => s.GetByNumberAsync(articleNumber, courseId)).ReturnsAsync(article);
            _arcticlesLikeServiceMock.Setup(s => s.LikeExistInArticle(article, user)).ReturnsAsync(null as LikeArticle);

            // Act
            var result = await _controller.Lesson(courseId, articleNumber);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.DoesNotContain("liked", viewResult.ViewData.Values);
        }
        [Fact]
        public async Task Lesson_ReturnsViewResult()
        {
            // Arrange
            int id = 1;
            byte number = 2;
            var user = new User();
            var article = new Article { Id = 1, Number = number, CourseId = id };
            _usersServiceMock.Setup(s => s.GetValueBy—onditionAsync(It.IsAny<Func<User, string>>(), It.IsAny<string>())).ReturnsAsync(user);
            _arcticlesServiceMock.Setup(s => s.GetByNumberAsync(number, id)).ReturnsAsync(article);
            _arcticlesLikeServiceMock.Setup(s => s.LikeExistInArticle(article, user)).ReturnsAsync((LikeArticle)null);

            // Act
            var result = await _controller.Lesson(id, number);

            // Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async Task Lesson_SetsNumberInViewBag()
        {
            // Arrange
            int id = 1;
            byte number = 2;
            var user = new User();
            var article = new Article { Id = 1, Number = number, CourseId = id };
            _usersServiceMock.Setup(s => s.GetValueBy—onditionAsync(It.IsAny<Func<User, string>>(), It.IsAny<string>())).ReturnsAsync(user);
            _arcticlesServiceMock.Setup(s => s.GetByNumberAsync(number, id)).ReturnsAsync(article);
            _arcticlesLikeServiceMock.Setup(s => s.LikeExistInArticle(article, user)).ReturnsAsync((LikeArticle)null);

            // Act
            var result = await _controller.Lesson(id, number);
            var viewResult = Assert.IsType<ViewResult>(result) as ViewResult;
        }


        [Fact]
        public async Task Details_ReturnsViewResult()
        {
            // Arrange
            int id = 1;
            _coursesServiceMock.Setup(s => s.GetByIdAllIncludesAsync(id)).ReturnsAsync(new Course());

            // Act
            var result = await _controller.Lesson(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }


    }
}