using AutoMapper;
using LearningSystem.BLL.Interfaces;
using LearningSystem.WEB.Controllers;
using LearningSystem.WEB.ValidationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        }

        //[Fact]
        //public async Task Lesson_ReturnsViewWithCorrectModel()
        //{
        //    // Arrange
        //    int id = 1;
        //    var model = new CourseModel { Id = id };
        //    _coursesServiceMock.Setup(s => s.GetByIdUserArticleIncludesAsync(id)).ReturnsAsync(model);

        //    // Act
        //    var result = await _controller.Lesson(id);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var resultModel = Assert.IsAssignableFrom<CourseModel>(viewResult.ViewData.Model);
        //    Assert.Equal(model, resultModel);
        //}

        //[Fact]
        //public async Task Lesson_ReturnsViewWithLikedFlagWhenUserLikesArticle()
        //{
        //    // Arrange
        //    int id = 1;
        //    int number = 2;
        //    var user = new User();
        //    var article = new Article { Id = 1, Number = number, CourseId = id };
        //    _usersServiceMock.Setup(s => s.GetValueBy—onditionAsync(It.IsAny<Expression<Func<User, string>>>(), It.IsAny<string>())).ReturnsAsync(user);
        //    _arcticlesServiceMock.Setup(s => s.GetByNumberAsync(number, id)).ReturnsAsync(article);
        //    _arcticlesLikeServiceMock.Setup(s => s.LikeExistInArticle(article, user)).ReturnsAsync(new ArticleLike());

        //    // Act
        //    var result = await _controller.Lesson(id, number);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    Assert.True((bool)viewResult.ViewBag.Liked);
        //}

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

    }
}