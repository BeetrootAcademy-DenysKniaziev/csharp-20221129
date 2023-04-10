
using LearningSystem.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LearningSystem.BLL.Tests
{
    public class CommentsServiceTests
    {
        private Mock<ICommentsRepository> _commentsRepositoryMock;
        private Mock<IUsersRepository> _usersRepositoryMock;
        private Mock<IArticlesRepository> _articlesRepositoryMock;

        private ICommentsService _commentsService;


        public CommentsServiceTests()
        {
            _commentsRepositoryMock = new Mock<ICommentsRepository>();
            _usersRepositoryMock = new Mock<IUsersRepository>();
            _articlesRepositoryMock = new Mock<IArticlesRepository>();

            _commentsService = new CommentsService(
                _commentsRepositoryMock.Object,
                _articlesRepositoryMock.Object,
                _usersRepositoryMock.Object
            );
        }

        [Fact]
        public async Task AddAsync_WhenCalledWithValidData_ShouldAddComment()
        {
            // Arrange
            var userId = 1;
            var articleId = 2;
            var comment = new Comment
            {
                UserId = userId,
                ArticleId = articleId,
                Content = "This is a valid comment."
            };

            _usersRepositoryMock.Setup(x => x.GetByIdAsync(userId))
                .ReturnsAsync(new User { Id = userId });
            _articlesRepositoryMock.Setup(x => x.GetByIdAsync(articleId))
                .ReturnsAsync(new Article { Id = articleId });

            // Act
            await _commentsService.AddAsync(comment);

            // Assert
            _commentsRepositoryMock.Verify(x => x.AddAsync(comment), Times.Once);
        }

        [Fact]
        public void AddAsync_WhenCalledWithNullComment_ShouldThrowArgumentNullException()
        {
            // Arrange
            Comment comment = null;

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _commentsService.AddAsync(comment));
        }

        [Fact]
        public void AddAsync_WhenCalledWithInvalidContent_ShouldThrowArgumentException()
        {
            // Arrange
            var comment = new Comment { Content = "" };

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => _commentsService.AddAsync(comment));
        }

        [Fact]
        public void AddAsync_WhenCalledWithInvalidUserId_ShouldThrowArgumentNullException()
        {
            // Arrange
            var comment = new Comment { UserId = 1 };

            _usersRepositoryMock.Setup(x => x.GetByIdAsync(comment.UserId))
                .ReturnsAsync(null as User);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _commentsService.AddAsync(comment));
        }

        [Fact]
        public void AddAsync_WhenCalledWithInvalidArticleId_ShouldThrowArgumentNullException()
        {
            // Arrange
            var comment = new Comment { ArticleId = 1 };

            _articlesRepositoryMock.Setup(x => x.GetByIdAsync(comment.ArticleId))
                .ReturnsAsync(null as Article);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _commentsService.AddAsync(comment));
        }

        [Fact]
        public async Task DeleteAsync_WhenCalled_ShouldDeleteComment()
        {
            // Arrange
            var comment = new Comment();

            // Act
            await _commentsService.DeleteAsync(comment);

            // Assert
            _commentsRepositoryMock.Verify(x => x.DeleteAsync(comment), Times.Once);
        }
        [Fact]
        public async Task GetAsync_WhenCalled_ShouldReturnAllComments()
        {
            // Arrange
            var comments = new List<Comment>
        {
            new Comment(),
            new Comment(),
            new Comment()
        };

            _commentsRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(comments);
            var result = await _commentsService.GetAsync();

            // Assert
            Assert.Equal(comments.Count, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_WhenCalledWithValidId_ShouldReturnComment()
        {
            // Arrange
            var comment = new Comment { Id = 1 };

            _commentsRepositoryMock.Setup(x => x.GetByIdAsync(comment.Id))
                .ReturnsAsync(comment);

            // Act
            var result = await _commentsService.GetByIdAsync(comment.Id);

            // Assert
            Assert.Equal(comment, result);
        }

        [Fact]
        public void GetByIdAsync_WhenCalledWithInvalidId_ShouldThrowArgumentNullException()
        {
            // Arrange
            var commentId = 1;

            _commentsRepositoryMock.Setup(x => x.GetByIdAsync(commentId))
                .ReturnsAsync(null as Comment);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _commentsService.GetByIdAsync(commentId));
        }

        [Fact]
        public async Task UpdateAsync_WhenCalledWithValidData_ShouldUpdateComment()
        {
            // Arrange
            var userId = 1;
            var articleId = 2;
            var comment = new Comment
            {
                Id = 3,
                UserId = userId,
                ArticleId = articleId,
                Content = "This is a valid comment."
            };

            _usersRepositoryMock.Setup(x => x.GetByIdAsync(userId))
                .ReturnsAsync(new User { Id = userId });
            _articlesRepositoryMock.Setup(x => x.GetByIdAsync(articleId))
                .ReturnsAsync(new Article { Id = articleId });

            // Act
            await _commentsService.UpdateAsync(comment);

            // Assert
            _commentsRepositoryMock.Verify(x => x.UpdateAsync(comment), Times.Once);
        }

        [Fact]
        public void UpdateAsync_WhenCalledWithNullComment_ShouldThrowArgumentNullException()
        {
            // Arrange
            Comment comment = null;

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _commentsService.UpdateAsync(comment));
        }

        [Fact]
        public void UpdateAsync_WhenCalledWithInvalidContent_ShouldThrowArgumentException()
        {
            // Arrange
            var comment = new Comment { Content = "" };

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => _commentsService.UpdateAsync(comment));
        }

        [Fact]
        public void UpdateAsync_WhenCalledWithInvalidUserId_ShouldThrowArgumentNullException()
        {
            // Arrange
            var comment = new Comment { UserId = 1 };

            _usersRepositoryMock.Setup(x => x.GetByIdAsync(comment.UserId))
                .ReturnsAsync(null as User);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _commentsService.UpdateAsync(comment));
        }

        [Fact]
        public void UpdateAsync_WhenCalledWithInvalidArticleId_ShouldThrowArgumentNullException()
        {
            // Arrange
            var comment = new Comment { ArticleId = 1 };

            _articlesRepositoryMock.Setup(x => x.GetByIdAsync(comment.ArticleId))
                .ReturnsAsync(null as Article);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _commentsService.UpdateAsync(comment));
        }

    }
}
