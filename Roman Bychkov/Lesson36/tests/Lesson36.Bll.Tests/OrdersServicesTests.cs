namespace Lesson36.Bl.Tests
{
    public class OrdersServicesTests
    {
        private readonly Mock<IOrdersRepository> _ordersRepositoryMock = new Mock<IOrdersRepository>();
        private readonly Mock<IPersonsRepository> _personsRepositoryMock = new Mock<IPersonsRepository>();
        private readonly Mock<IProductsRepository> _productsRepositoryMock = new Mock<IProductsRepository>();

        private readonly IOrdersServices _ordersServices;

        public OrdersServicesTests()
        {
            _ordersServices = new OrdersServices(_ordersRepositoryMock.Object, _productsRepositoryMock.Object, _personsRepositoryMock.Object);
        }

        [Fact]
        public async Task Add_ThrowsArgumentNullException_WhenProductDoesNotExist()
        {
            // Arrange
            var order = new Order { ProductId = 1, PersonId = 1 };
            _productsRepositoryMock.Setup(x => x.GetById(order.ProductId)).ReturnsAsync((Product)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _ordersServices.Add(order));
        }

        [Fact]
        public async Task Add_ThrowsArgumentNullException_WhenPersonDoesNotExist()
        {
            // Arrange
            var order = new Order { ProductId = 1, PersonId = 1 };
            _productsRepositoryMock.Setup(x => x.GetById(order.ProductId)).ReturnsAsync(new Product());
            _personsRepositoryMock.Setup(x => x.GetById(order.PersonId)).ReturnsAsync((Person)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _ordersServices.Add(order));
        }

        [Fact]
        public async Task Add_CallsOrdersRepositoryAdd_WhenProductAndPersonExist()
        {
            // Arrange
            var order = new Order { ProductId = 1, PersonId = 1 };
            _productsRepositoryMock.Setup(x => x.GetById(order.ProductId)).ReturnsAsync(new Product());
            _personsRepositoryMock.Setup(x => x.GetById(order.PersonId)).ReturnsAsync(new Person());

            // Act
            await _ordersServices.Add(order);

            // Assert
            _ordersRepositoryMock.Verify(x => x.Add(order), Times.Once);
        }

        [Fact]
        public async Task Delete_ThrowsArgumentNullException_WhenOrderIsNull()
        {
            // Arrange
            Order order = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _ordersServices.Delete(order));
        }

        [Fact]
        public async Task Delete_CallsOrdersRepositoryDelete_WhenOrderIsNotNull()
        {
            // Arrange
            var order = new Order();

            // Act
            await _ordersServices.Delete(order);

            // Assert
            _ordersRepositoryMock.Verify(x => x.Delete(order), Times.Once);
        }

        [Fact]
        public async Task Get_CallsOrdersRepositoryGet()
        {
            // Act
            await _ordersServices.Get();

            // Assert
            _ordersRepositoryMock.Verify(x => x.Get(), Times.Once);
        }

        [Fact]
        public async Task GetById_CallsOrdersRepositoryGetById()
        {
            // Arrange
            var id = 1;

            // Act
            await _ordersServices.GetById(id);

            // Assert
            _ordersRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        }

        [Fact]
        public async Task Update_ThrowsArgumentNullException_WhenOrderDoesNotExist()
        {
            // Arrange
            var order = new Order { ProductId = 1, PersonId = 1 };
            var id = 1;
            _ordersRepositoryMock.Setup(x => x.GetById(id)).ReturnsAsync((Order)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _ordersServices.Update(order, id));
        }
    }
}
