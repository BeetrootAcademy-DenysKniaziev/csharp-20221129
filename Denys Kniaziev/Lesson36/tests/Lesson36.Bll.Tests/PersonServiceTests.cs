using FluentValidation;
using FluentValidation.Results;
using Lesson36.Bll.Services;
using Lesson36.Bll.Utils;
using Lesson36.Contracts;
using Lesson36.Dal.Repositories;
using Moq;

namespace Lesson36.Bll.Tests
{
    public class PersonServiceTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllPersons()
        {
            // Arrange
            var persons = new List<Person>
                {
                    new Person { Id = 1, },
                    new Person { Id = 2  }
                };

            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(persons);
            var mockValidator = new Mock<IValidator<Person>>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();

            var personService = new PersonService(mockRepository.Object, mockDateTimeProvider.Object, mockValidator.Object);

            // Act
            var result = await personService.GetAll();

            // Assert
            Assert.Equal(persons, result);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectPerson()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John" };

            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(repo => repo.GetById(person.Id)).ReturnsAsync(person);
            var mockValidator = new Mock<IValidator<Person>>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();

            var personService = new PersonService(mockRepository.Object, mockDateTimeProvider.Object, mockValidator.Object);

            // Act
            var result = await personService.GetById(person.Id);

            // Assert
            Assert.Equal(person, result);
        }

        [Fact]
        public async Task Add_SetsCreatedAtAndReturnsId()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John" };
            var dateTime = DateTime.UtcNow;

            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(repo => repo.Add(person)).ReturnsAsync(person.Id);
            var mockValidator = new Mock<IValidator<Person>>();
            mockValidator.Setup(validator => validator.ValidateAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new ValidationResult()));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockDateTimeProvider.Setup(provider => provider.UtcNow).Returns(dateTime);

            var personService = new PersonService(mockRepository.Object, mockDateTimeProvider.Object, mockValidator.Object);

            // Act
            var result = await personService.Add(person);

            // Assert
            Assert.Equal(person.Id, result.Data);
            Assert.Equal(dateTime, person.CreatedAt);
        }

        [Fact]
        public async Task Update_CallsRepositoryUpdate()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John" };
            var mockRepository = new Mock<IPersonRepository>();
            var mockValidator = new Mock<IValidator<Person>>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var personService = new PersonService(mockRepository.Object, mockDateTimeProvider.Object, mockValidator.Object);

            // Act
            await personService.Update(person);

            // Assert
            mockRepository.Verify(repo => repo.Update(person), Times.Once);
        }

        [Fact]
        public async Task Delete_CallsRepositoryDelete()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John" };
            var mockRepository = new Mock<IPersonRepository>();
            var mockValidator = new Mock<IValidator<Person>>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var personService = new PersonService(mockRepository.Object, mockDateTimeProvider.Object, mockValidator.Object);

            // Act
            await personService.Delete(person);

            // Assert
            mockRepository.Verify(repo => repo.Delete(person), Times.Once);
        }
    }

}
