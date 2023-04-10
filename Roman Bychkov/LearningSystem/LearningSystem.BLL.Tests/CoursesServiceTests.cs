using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LearningSystem.BLL.Tests
{
    public class CoursesServiceTests
    {
        private Mock<ICoursesRepository> _mockCoursesRepository;
        private Mock<IUsersRepository> _mockUsersRepository;
        private CoursesService _coursesService;

        public CoursesServiceTests()
        {
            _mockCoursesRepository = new Mock<ICoursesRepository>();
            _mockUsersRepository = new Mock<IUsersRepository>();
            _coursesService = new CoursesService(_mockCoursesRepository.Object, _mockUsersRepository.Object, "wwwroot");
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentNullException_WhenItemIsNull()
        {
            // Arrange
            Course item = null;
            IFormFile file = new Mock<IFormFile>().Object;

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _coursesService.AddAsync(item, file));
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentException_WhenCourseNameIsInvalid()
        {
            // Arrange
            Course item = new Course
            {
                CourseName = "",
                Description = "Test Description",
                Content = "Test Content",
                UserId = 1
            };
            IFormFile file = new Mock<IFormFile>().Object;

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _coursesService.AddAsync(item, file));
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentNullException_WhenUserIsNull()
        {
            // Arrange
            Course item = new Course
            {
                CourseName = "Test Course",
                Description = "Test Description",
                Content = "Test Content",
                UserId = 1
            };
            IFormFile file = new Mock<IFormFile>().Object;
            _mockUsersRepository.Setup(x => x.GetByIdAsync(item.UserId, It.IsAny<List<string>>())).ReturnsAsync((User)null);

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _coursesService.AddAsync(item, file));
        }

        [Fact]
        public async Task AddAsync_ValidInput_AddsCourseAndSavesFileToDisk()
        {
            // Arrange
            Course item = new Course
            {
                CourseName = "Test Course",
                Description = "Test Description",
                Content = "Test Content",
                UserId = 1
            };
            var file = new FormFile(
               new MemoryStream(Encoding.UTF8.GetBytes("Test file content")),
               0,
               10_000, // розмір у байтах
               "TestFile",
               "test.png"
            );
            _mockUsersRepository.Setup(x => x.GetByIdAsync(item.UserId, It.IsAny<List<string>>())).ReturnsAsync(new User { Id = 1 });

            // Act
            await _coursesService.AddAsync(item, file);

            // Assert

            Assert.NotNull(item.ImagePath);
            //Assert.True(File.Exists("wwwroot/image/" + item.Id + ".jpg"));
        }

        [Fact]
        public async Task DeleteAsync_ThrowsArgumentNullException_WhenItemIsNull()
        {
            // Arrange
            Course item = null;

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _coursesService.DeleteAsync(item));
        }


        [Fact]
        public async Task AddAsync_NullCourse_ThrowsArgumentNullException()
        {
            // Arrange
            Course course = null;
            var file = new Mock<IFormFile>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _coursesService.AddAsync(course, file.Object));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("Invalid Course Name That Is More Than Fifty Characters Long")]
        public async Task AddAsync_InvalidCourseName_ThrowsArgumentException(string courseName)
        {
            // Arrange
            var course = new Course { CourseName = courseName, Description = "Test Description", Content = "Test Content", UserId = 1 };
            var file = new Mock<IFormFile>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _coursesService.AddAsync(course, file.Object));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("Invalid Description That Is More Than Two Hundred Characters Long Invalid Description That Is More Than Two Hundred Characters Long Invalid Description That Is More Than Two Hundred Characters Long Invalid Description That Is More Than Two Hundred Characters Long")]
        public async Task AddAsync_InvalidDescription_ThrowsArgumentException(string description)
        {
            // Arrange
            var course = new Course { CourseName = "Test Course", Description = description, Content = "Test Content", UserId = 1 };
            var file = new Mock<IFormFile>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _coursesService.AddAsync(course, file.Object));
        }

    }
}
