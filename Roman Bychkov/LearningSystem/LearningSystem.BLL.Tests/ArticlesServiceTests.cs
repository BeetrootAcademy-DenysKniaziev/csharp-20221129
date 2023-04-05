using LearningSystem.BLL.Interfaces;

namespace LearningSystem.BLL.Tests
{
    public class ArticlesServiceTests
    {
        private Mock<IArticlesRepository> _mockArticlesRepository;
        private Mock<ICoursesRepository> _mockCoursesRepository;
        private IArticlesService _articlesService;

        public ArticlesServiceTests()
        {
            _mockArticlesRepository = new Mock<IArticlesRepository>();
            _mockCoursesRepository = new Mock<ICoursesRepository>();
            _articlesService = new ArticlesService(_mockArticlesRepository.Object, _mockCoursesRepository.Object);
        }

        [Fact]
        public async Task AddAsync_ValidItem_CallsAddAsync()
        {
            // Arrange
            var article = new Article
            {
                ArticleName = "Valid article name",
                Content = "Valid content",
                CourseId = 1
            };

            _mockCoursesRepository
                .Setup(x => x.GetByIdAsync(article.CourseId))
                .ReturnsAsync(new Course { Id = article.CourseId });

            // Act
            await _articlesService.AddAsync(article);

            // Assert
            _mockArticlesRepository.Verify(x => x.AddAsync(article), Times.Once);
        }

        [Fact]
        public async Task AddAsync_NullItem_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            async Task result() => await _articlesService.AddAsync(null);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(result);
        }

        [Fact]
        public async Task AddAsync_InvalidNameArticle_ThrowsArgumentException()
        {
            // Arrange
            var article = new Article
            {
                ArticleName = "a",
                Content = "Valid content",
                CourseId = 1
            };

            // Act
            async Task result() => await _articlesService.AddAsync(article);

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(result);
        }

        [Fact]
        public async Task AddAsync_InvalidContent_ThrowsArgumentException()
        {
            // Arrange
            var article = new Article
            {
                ArticleName = "Valid article name",
                Content = new string('a', 10001),
                CourseId = 1
            };

            // Act
            async Task result() => await _articlesService.AddAsync(article);

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(result);
        }

        [Fact]
        public async Task AddAsync_InvalidCourseId_ThrowsArgumentNullException()
        {
            // Arrange
            var article = new Article
            {
                ArticleName = "Valid article name",
                Content = "Valid content",
                CourseId = 1
            };

            _mockCoursesRepository
                .Setup(x => x.GetByIdAsync(article.CourseId))
                .ReturnsAsync(null as Course);

            // Act
            async Task result() => await _articlesService.AddAsync(article);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(result);
        }

        [Fact]
        public async Task DeleteAsync_ValidItem_CallsDeleteAsync()
        {
            // Arrange
            var article = new Article
            {
                Id = 1,
                Number = 1,
                ArticleName = "Valid article name",
                Content = "Valid content",
                CourseId = 1
            };

            _mockArticlesRepository.Setup(x => x.GetByIdAsync(article.Id)).ReturnsAsync(article);

            // Act
            await _articlesService.DeleteAsync(article);

            // Assert
            _mockArticlesRepository.Verify(x => x.DeleteAsync(article), Times.Once);
        }
        [Fact]
        public async Task GetByNumberAsync_ShouldReturnArticle_WhenArticleExists()
        {
            // Arrange
            var courseId = 1;
            byte number = 2;
            var expectedArticle = new Article { Id = 1, CourseId = courseId, Number = number };
            _mockArticlesRepository
                .Setup(x => x.GetByNumberAsync(number, courseId))
                .ReturnsAsync(expectedArticle);

            // Act
            var result = await _articlesService.GetByNumberAsync(number, courseId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Article>(result);
            Assert.Equal(expectedArticle, result);
        }

        [Fact]
        public async Task GetByNumberAsync_ShouldReturnNull_WhenArticleDoesNotExist()
        {
            // Arrange
            var courseId = 1;
            var number = 2;
            _mockArticlesRepository
                .Setup(x => x.GetByNumberAsync(number, courseId))
                .ReturnsAsync(null as Article);

            // Act
            var result = await _articlesService.GetByNumberAsync(number, courseId);

            // Assert
            Assert.Null(result);
        }
    }
}
