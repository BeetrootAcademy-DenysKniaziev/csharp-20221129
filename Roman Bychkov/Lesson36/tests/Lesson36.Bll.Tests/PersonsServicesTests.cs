

namespace Lesson36.Bll.Tests
{
    public class PersonsServicesTests
    {
        private readonly Mock<IPersonsRepository> _repositoryMock = new Mock<IPersonsRepository>();
        private readonly IPersonsServices _service;

        public PersonsServicesTests()
        {
            _service = new PersonsServices(_repositoryMock.Object);
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonFirstNameIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person { FirstName = "", LastName = "Doe", Age = 30, Gender = "Male", Address = "123 Main St" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.Add(person));
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonLastNameIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "", Age = 30, Gender = "Male", Address = "123 Main St" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.Add(person));
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonAgeIsLessThanOrEqualTo16()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 16, Gender = "Male", Address = "123 Main St" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.Add(person));
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonGenderIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, Gender = "", Address = "123 Main St" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.Add(person));
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonAddressIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male", Address = "" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.Add(person));
        }

        [Fact]
        public async Task Add_CallsRepositoryAddMethod_WhenPersonIsValid()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male", Address = "123 Main St" };

            // Act
            await _service.Add(person);

            // Assert
            _repositoryMock.Verify(x => x.Add(person), Times.Once);
        }

        [Fact]
        public async Task Delete_ThrowsArgumentNullException_WhenPersonIsNull()
        {
            // Arrange
            Person person = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Delete(person));
        }

        [Fact]
        public async Task Delete_CallsRepositoryDeleteMethod_WhenPersonIsNotNull()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male", Address = "123 Main St" };

            // Act
            await _service.Delete(person);

            // Assert
            _repositoryMock.Verify(x => x.Delete(person), Times.Once);
        }

    }
}