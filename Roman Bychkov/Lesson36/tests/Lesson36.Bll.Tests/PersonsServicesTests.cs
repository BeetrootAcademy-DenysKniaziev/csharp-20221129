

namespace Lesson36.Bl.Tests
{
    public class PersonsServicesTests
    {
        private readonly Mock<IPersonsRepository> _personsRepositoryMock;
        private readonly IPersonsServices _personsServices;

        public PersonsServicesTests()
        {
            _personsRepositoryMock = new Mock<IPersonsRepository>();
            _personsServices = new PersonsServices(_personsRepositoryMock.Object);
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonFirstNameIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person { FirstName = "", LastName = "Doe", Age = 30, Gender = "Male", Address = "123 Main St" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonLastNameIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "", Age = 30, Gender = "Male", Address = "123 Main St" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonAgeIsLessThanOrEqualTo16()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 16, Gender = "Male", Address = "123 Main St" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonGenderIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, Gender = "", Address = "123 Main St" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_ThrowsArgumentException_WhenPersonAddressIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male", Address = "" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_CallsRepositoryAddMethod_WhenPersonIsValid()
        {
            // Arrange
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male", Address = "123 Main St" };

            // Act
            await _personsServices.Add(person);

            // Assert
            _personsRepositoryMock.Verify(x => x.Add(person), Times.Once);
        }

        [Fact]
        public async Task Delete_ThrowsArgumentNullException_WhenPersonIsNull()
        {
            // Arrange
            Person person = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _personsServices.Delete(person));
        }

        [Fact]
        public async Task Delete_CallsRepositoryDeleteMethod_WhenPersonIsNotNull()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male", Address = "123 Main St" };

            // Act
            await _personsServices.Delete(person);

            // Assert
            _personsRepositoryMock.Verify(x => x.Delete(person), Times.Once);
        }
        [Fact]
        public async Task Add_ShouldThrowArgumentException_WhenFirstNameIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person
            {
                FirstName = null,
                LastName = "Doe",
                Age = 30,
                Gender = "Male",
                Address = "123 Main St."
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_ShouldThrowArgumentException_WhenLastNameIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = null,
                Age = 30,
                Gender = "Male",
                Address = "123 Main St."
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_ShouldThrowArgumentException_WhenAgeIsLessThanOrEqualTo16()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 16,
                Gender = "Male",
                Address = "123 Main St."
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_ShouldThrowArgumentException_WhenGenderIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Gender = null,
                Address = "123 Main St."
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_ShouldThrowArgumentException_WhenAddressIsNullOrWhiteSpace()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Gender = "Male",
                Address = null
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _personsServices.Add(person));
        }

        [Fact]
        public async Task Add_ShouldCallAddMethodOfRepository_WhenPersonIsValid()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Gender = "Male",
                Address = "123 Main St."
            };

            // Act
            await _personsServices.Add(person);

            // Assert
            _personsRepositoryMock.Verify(x => x.Add(person), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldThrowArgumentNullException_WhenPersonIsNull()
        {
            // Arrange
            Person person = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _personsServices.Delete(person));
        }
    }
}