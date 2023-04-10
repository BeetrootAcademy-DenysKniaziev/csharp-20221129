
using Castle.Core.Configuration;
using LearningSystem.WEB.ValidationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LearningSystem.Controller.Tests
{

    public class AccountControllerTests
    {
        private readonly Mock<ILogger<AccountController>> _loggerMock = new Mock<ILogger<AccountController>>();
        private readonly Mock<IUsersServices> _serviceMock = new Mock<IUsersServices>();
        private readonly Mock<IConfiguration> _configurationMock = new Mock<IConfiguration>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _controller = new AccountController(_loggerMock.Object, _serviceMock.Object, _configurationMock.Object as Microsoft.Extensions.Configuration.IConfiguration, _mapperMock.Object);

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
        public async Task Login_ReturnsViewResult()
        {
            // Act
            var result = await _controller.Login();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public async Task Logout_ReturnsRedirectToActionResult()
        {
            // Act

            var result = await _controller.Logout();

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
        }

        [Fact]
        public async Task Login_WithNonExistingUser_ReturnsViewResultWithModelError()
        {
            // Arrange
            var loginModel = new LoginModel { UserName = "nonexistinguser", Password = "password" };
            _serviceMock.Setup(x => x.GetValueByСonditionAsync(It.IsAny<Func<User, string>>(), loginModel.UserName)).ReturnsAsync(null as User);

            // Act
            var result = await _controller.Login(loginModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var modelState = Assert.IsType<ModelStateDictionary>(viewResult.ViewData.ModelState);
            Assert.True(modelState.ContainsKey("UserName"));
            Assert.Equal("Такого акаунта не існує", modelState["UserName"].Errors[0].ErrorMessage);
        }

        [Fact]
        public async Task Login_WithInvalidPassword_ReturnsViewResultWithModelError()
        {
            // Arrange
            var loginModel = new LoginModel { UserName = "existinguser", Password = "wrongpassword" };
            var existingUser = new User { UserName = loginModel.UserName, Email = "existinguser@example.com" };
            _serviceMock
    .Setup(x => x.GetValueByСonditionAsync(It.IsAny<Func<User, string>>(), loginModel.UserName))
    .ReturnsAsync(existingUser);
            _serviceMock.Setup(x => x.GetUserByLoginPasswordAsync(loginModel.UserName, loginModel.Password)).ReturnsAsync(null as User);

            // Act
            var result = await _controller.Login(loginModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var modelState = Assert.IsType<ModelStateDictionary>(viewResult.ViewData.ModelState);
            Assert.True(modelState.ContainsKey("Password"));
            Assert.Equal("Пароль не вірний", modelState["Password"].Errors[0].ErrorMessage);
        }
        [Fact]
        public async Task Login_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var model = new LoginModel();
            _controller.ModelState.AddModelError("UserName", "The UserName field is required.");

            // Act
            var result = await _controller.Login(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public async Task Login_ReturnsViewResult_WhenUserNameDoesNotExist()
        {
            // Arrange
            var model = new LoginModel { UserName = "nonexistinguser", Password = "testpassword" };
            _serviceMock.Setup(x => x.GetValueByСonditionAsync(It.IsAny<Func<User, string>>(), model.UserName)).ReturnsAsync((User)null);

            // Act
            var result = await _controller.Login(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.True(_controller.ModelState.ContainsKey(nameof(model.UserName)));
            Assert.Equal("Такого акаунта не існує", _controller.ModelState[nameof(model.UserName)].Errors[0].ErrorMessage);
        }

        [Fact]
        public async Task Login_ReturnsViewResult_WhenPasswordIsIncorrect()
        {
            // Arrange
            var model = new LoginModel { UserName = "existinguser", Password = "testpassword" };
            var existingUser = new User { UserName = "existinguser", Password = "testpassword1", Email = "test@test.com" };
            _serviceMock.Setup(x => x.GetValueByСonditionAsync(It.IsAny<Func<User, string>>(), model.UserName)).ReturnsAsync(existingUser);

            // Act
            var result = await _controller.Login(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            //Assert.True(_controller.ModelState.ContainsKey(nameof(model.Password)));
            Assert.Equal("Пароль не вірний", _controller.ModelState[nameof(model.Password)].Errors[0].ErrorMessage);
        }


    }
}
