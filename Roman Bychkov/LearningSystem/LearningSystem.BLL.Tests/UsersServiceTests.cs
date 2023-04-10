

namespace LearningSystem.BLL.Tests
{
    public class UsersServiceTests
    {
        private readonly Mock<IUsersRepository> _mockRepository;
        private readonly UsersService _service;

        public UsersServiceTests()
        {
            _mockRepository = new Mock<IUsersRepository>();
            _service = new UsersService(_mockRepository.Object);
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentNullException_WhenUserIsNull()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.AddAsync(null));
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentException_WhenUsernameIsInvalid()
        {
            // Arrange
            var user = new User { UserName = "", Password = "password", Email = "user@example.com" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddAsync(user));
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentException_WhenPasswordIsInvalid()
        {
            // Arrange
            var user = new User { UserName = "username", Password = "", Email = "user@example.com" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddAsync(user));
        }

        [Fact]
        public async Task AddAsync_ThrowsArgumentException_WhenEmailIsInvalid()
        {
            // Arrange
            var user = new User { UserName = "username", Password = "password", Email = "invalid_email" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddAsync(user));
        }

        [Fact]
        public async Task AddAsync_CallsAddAsyncMethod_WhenUserIsValid()
        {
            // Arrange
            var user = new User { UserName = "username", Password = "password", Email = "user@example.com" };

            // Act
            await _service.AddAsync(user);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(user), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ThrowsArgumentNullException_WhenUserIsNull()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteAsync(null));
        }

        [Fact]
        public async Task DeleteAsync_CallsDeleteAsyncMethod_WhenUserIsValid()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "username", Password = "password", Email = "user@example.com" };

            // Act
            await _service.DeleteAsync(user);

            // Assert
            _mockRepository.Verify(r => r.DeleteAsync(user), Times.Once);
        }

        [Fact]
        public async Task GetAsync_CallsGetAllAsyncMethod()
        {
            // Act
            await _service.GetAsync();

            // Assert
            _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_CallsGetByIdAsyncMethod_WhenIdIsValid()
        {
            // Arrange
            var userId = 1;

            // Act
            await _service.GetByIdAsync(userId);

            // Assert
            _mockRepository.Verify(r => r.GetByIdAsync(userId), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsArgumentNullException_WhenUserIsNull()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateAsync(null));
        }

        [Fact]
        public async Task UpdateAsync_ThrowsArgumentException_WhenUsernameIsInvalid()
        {
            // Arrange
            var user = new User { UserName = "", Password = "password", Email = "user@example.com" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateAsync(user));
        }
        [Fact]
        public async Task AddAsync_ValidUser_ReturnsTrue()
        {
            // Arrange
            var user = new User
            {
                UserName = "testuser",
                Password = "password123",
                Email = "testuser@example.com",
                Image = "testimage.jpg"
            };

            // Act
            await _service.AddAsync(user);

            // Assert
            _mockRepository.Verify(x => x.AddAsync(user), Times.Once);
        }

        [Fact]
        public async Task AddAsync_NullUser_ThrowsException()
        {
            // Arrange
            User user = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.AddAsync(user));
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
        public async Task AddAsync_InvalidUserName_ThrowsException(string userName)
        {
            // Arrange
            var user = new User
            {
                UserName = userName,
                Password = "password123",
                Email = "testuser@example.com",
                Image = "testimage.jpg"
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddAsync(user));
        }

        [Theory]
        [InlineData("")]
        [InlineData("12")]
        [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
        public async Task AddAsync_InvalidPassword_ThrowsException(string password)
        {
            // Arrange
            var user = new User
            {
                UserName = "testuser",
                Password = password,
                Email = "testuser@example.com",
                Image = "testimage.jpg"
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddAsync(user));
        }

        [Theory]
        [InlineData("testuser")]
        [InlineData("testuser@")]
        [InlineData("@example.com")]
        [InlineData("testuser@example")]
        [InlineData("testuser@.com")]
        public async Task AddAsync_InvalidEmail_ThrowsException(string email)
        {
            // Arrange
            var user = new User
            {
                UserName = "testuser",
                Password = "password123",
                Email = email,
                Image = "testimage.jpg"
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddAsync(user));
        }

        [Fact]
        public async Task DeleteAsync_ValidUser_ReturnsTrue()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                UserName = "testuser",
                Password = "password123",
                Email = "testuser@example.com",
                Image = "testimage.jpg"
            };

            // Act
            await _service.DeleteAsync(user);

            // Assert
            _mockRepository.Verify(x => x.DeleteAsync(user), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_NullUser_ThrowsException()
        {
            // Arrange
            User user = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteAsync(user));
        }

    }
}