namespace LearningSystem.BLL.Tests
{
    public class LikeArticleServiceTests
    {
        private readonly Mock<ILikeArticleRepository> _likeArticleRepositoryMock;
        private readonly Mock<IUsersRepository> _usersRepositoryMock;
        private readonly Mock<IArticlesRepository> _articlesRepositoryMock;
        private readonly LikeArticleService _likeArticleService;

        public LikeArticleServiceTests()
        {
            _likeArticleRepositoryMock = new Mock<ILikeArticleRepository>();
            _usersRepositoryMock = new Mock<IUsersRepository>();
            _articlesRepositoryMock = new Mock<IArticlesRepository>();
            _likeArticleService = new LikeArticleService(_likeArticleRepositoryMock.Object, _articlesRepositoryMock.Object, _usersRepositoryMock.Object);
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentNullException_WhenItemIsNull()
        {
            // Arrange
            LikeArticle item = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _likeArticleService.AddAsync(item));
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentNullException_WhenUserIdIsNull()
        {
            // Arrange
            var item = new LikeArticle { UserId = 0 };

            _usersRepositoryMock.Setup(x => x.GetByIdAsync(item.UserId)).ReturnsAsync((User)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _likeArticleService.AddAsync(item));
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentNullException_WhenArticleIdIsNull()
        {
            // Arrange
            var item = new LikeArticle { ArticleId = 0 };

            _articlesRepositoryMock.Setup(x => x.GetByIdAsync(item.ArticleId)).ReturnsAsync((Article)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _likeArticleService.AddAsync(item));
        }

        [Fact]
        public async Task AddAsync_CallsAddAsyncOnContext_WhenItemIsValid()
        {
            // Arrange
            var item = new LikeArticle { UserId = 1, ArticleId = 1 };

            _usersRepositoryMock.Setup(x => x.GetByIdAsync(item.UserId)).ReturnsAsync(new User());
            _articlesRepositoryMock.Setup(x => x.GetByIdAsync(item.ArticleId)).ReturnsAsync(new Article());

            // Act
            await _likeArticleService.AddAsync(item);

            // Assert
            _likeArticleRepositoryMock.Verify(x => x.AddAsync(item), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ThrowsArgumentNullException_WhenItemIsNull()
        {
            // Arrange
            LikeArticle item = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _likeArticleService.DeleteAsync(item));
        }

        [Fact]
        public async Task DeleteAsync_CallsDeleteAsyncOnContext_WhenItemIsValid()
        {
            // Arrange
            var item = new LikeArticle { UserId = 1, ArticleId = 1 };

            // Act
            await _likeArticleService.DeleteAsync(item);

            // Assert
            _likeArticleRepositoryMock.Verify(x => x.DeleteAsync(item), Times.Once);
        }

        [Fact]
        public async Task GetAsync_CallsGetAsyncOnContext()
        {
            // Act
            await _likeArticleService.GetAsync();

            // Assert
            _likeArticleRepositoryMock.Verify(x => x.GetAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_CallsGetByIdAsyncOnContext()
        {
            // Arrange
            var id = 1;

            // Act
            await _likeArticleService.GetByIdAsync(id);

            // Assert
            _likeArticleRepositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once);
        }


        [Fact]
        public async Task LikeExistInArticle_ReturnsCorrectResult_WhenArticleAndUserExistInDatabase()
        {
            // Arrange
            var article = new Article { Id = 1 };
            var user = new User { Id = 1 };
            var expectedResult = new LikeArticle { Id = 1, UserId = user.Id, ArticleId = article.Id };



            _likeArticleRepositoryMock.Setup(x => x.LikeExistInArticle(article, user)).ReturnsAsync(expectedResult);

            // Act
            var result = await _likeArticleService.LikeExistInArticle(article, user);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LikeExistInArticle_ReturnsNull_WhenArticleOrUserDoNotExistInDatabase()
        {
            // Arrange
            var article = new Article { Id = 1 };
            var user = new User { Id = 1 };

            _likeArticleRepositoryMock.Setup(x => x.LikeExistInArticle(article, user)).ReturnsAsync((LikeArticle)null);

            // Act
            var result = await _likeArticleService.LikeExistInArticle(article, user);

            // Assert
            Assert.Null(result);
        }
    }
}
