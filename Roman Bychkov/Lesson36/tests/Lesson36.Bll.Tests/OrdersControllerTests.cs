
namespace Lesson36.Bl.Tests
{
    public class OrdersControllerTests
    {
        private readonly Mock<IOrdersServices> _mockOrdersServices;
        private readonly OrdersController _controller;

        public OrdersControllerTests()
        {
            _mockOrdersServices = new Mock<IOrdersServices>();
            _controller = new OrdersController(_mockOrdersServices.Object);
        }
        [Fact]
        public async Task GetAll_ReturnsOkObjectResult_WithOrders()
        {
            // Arrange
            var orders = new List<Order> { new Order { Id = 1 }, new Order { Id = 2 } };
            _mockOrdersServices.Setup(x => x.Get()).ReturnsAsync(orders);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedOrders = Assert.IsAssignableFrom<IEnumerable<Order>>(okObjectResult.Value);
            Assert.Equal(orders.Count, returnedOrders.Count());
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            var expectedOrders = new List<Order>();
            _mockOrdersServices.Setup(s => s.Get()).ReturnsAsync(expectedOrders);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedOrders, okResult.Value);
        }

        [Fact]
        public async Task GetById_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var expectedOrder = new Order();
            _mockOrdersServices.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(expectedOrder);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedOrder, okResult.Value);
        }

        [Fact]
        public async Task GetById_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _mockOrdersServices.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(null as Order);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
