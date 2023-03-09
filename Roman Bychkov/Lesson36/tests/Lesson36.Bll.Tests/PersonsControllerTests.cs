

namespace Lesson36.Bl.Tests
{
    public class PersonsControllerTests
    {
        private Mock<IPersonsServices> _personsServiceMock = new Mock<IPersonsServices>();
        private PersonsController _controller;

        public PersonsControllerTests()
        {
            _personsServiceMock = new Mock<IPersonsServices>();
            _controller = new PersonsController(_personsServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkObjectResult()
        {
            // Arrange
            var persons = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male", Address = "123 Main St" },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe", Age = 25, Gender = "Female", Address = "456 Elm St" }
        };
            _personsServiceMock.Setup(x => x.Get()).ReturnsAsync(persons);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task GetById_WithValidId_ReturnsOkObjectResult()
        {
            // Arrange
            int personId = 1;
            var person = new Person { Id = personId, FirstName = "John", LastName = "Doe", Age = 30, Gender = "Male", Address = "123 Main St" };
            _personsServiceMock.Setup(x => x.GetById(personId)).ReturnsAsync(person);

            // Act
            var result = await _controller.GetById(personId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Person>(okResult.Value);
            Assert.Equal(personId, model.Id);
        }

        [Fact]
        public async Task GetById_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            int personId = 1;
            _personsServiceMock.Setup(x => x.GetById(personId)).ReturnsAsync((Person)null);

            // Act
            var result = await _controller.GetById(personId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task GetAll_Returns_OkResult_With_List_Of_Persons()
        {
            // Arrange
            var persons = new List<Person> { new Person { Id = 1 }, new Person { Id = 2 } };
            _personsServiceMock.Setup(x => x.Get()).ReturnsAsync(persons);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<Person>>(okResult.Value);
            Assert.Equal(persons.Count, model.Count);
        }

        [Fact]
        public async Task GetById_Returns_OkResult_With_Person_When_Person_Exists()
        {
            // Arrange
            var person = new Person { Id = 1 };
            _personsServiceMock.Setup(x => x.GetById(person.Id)).ReturnsAsync(person);

            // Act
            var result = await _controller.GetById(person.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Person>(okResult.Value);
            Assert.Equal(person.Id, model.Id);
        }

        [Fact]
        public async Task GetById_Returns_NotFoundResult_When_Person_Does_Not_Exist()
        {
            // Arrange
            var id = 1;
            _personsServiceMock.Setup(x => x.GetById(id)).ReturnsAsync((Person)null);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task PostPerson_Returns_CreatedAtRouteResult_With_Person()
        {
            // Arrange
            var personJson = new PersonsController.PersonJSON
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Gender = "Male",
                Address = "123 Main St."
            };
            var newPerson = new Person
            {
                FirstName = personJson.FirstName,
                LastName = personJson.LastName,
                Age = personJson.Age,
                Gender = personJson.Gender,
                Address = personJson.Address
            };

            
            _personsServiceMock.Setup(x => x.Add(It.IsAny<Person>())).Returns(Task.FromResult<Person>(newPerson));
        
            // Act
            var result = await _controller.PostPerson(personJson);

            // Assert
            var createdAtRouteResult = Assert.IsType<CreatedResult>(result);
            var model = Assert.IsType<Person>(createdAtRouteResult.Value);
            Assert.Equal(newPerson.Id, model.Id);
            Assert.Equal(newPerson.FirstName, model.FirstName);
            Assert.Equal(newPerson.LastName, model.LastName);
            Assert.Equal(newPerson.Age, model.Age);
            Assert.Equal(newPerson.Gender, model.Gender);
            Assert.Equal(newPerson.Address, model.Address);
        }
    }
}
