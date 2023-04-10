
namespace Lesson36.Bl.Tests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductsServices> _productsServicesMock;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _productsServicesMock = new Mock<IProductsServices>();
            _controller = new ProductsController(_productsServicesMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResult_WhenProductsExist()
        {
            // Arrange
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1" },
            new Product { Id = 2, Name = "Product 2" }
        };
            _productsServicesMock.Setup(x => x.Get()).ReturnsAsync(products);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task GetById_ShouldReturnOkResult_WhenProductExists()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product 1" };
            _productsServicesMock.Setup(x => x.GetById(1)).ReturnsAsync(product);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Product>(okResult.Value);
            Assert.Equal(product.Id, model.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFoundResult_WhenProductDoesNotExist()
        {
            // Arrange
            _productsServicesMock.Setup(x => x.GetById(1)).ReturnsAsync((Product)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnOkResult_WhenProductIsDeleted()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product 1" };
            _productsServicesMock.Setup(x => x.GetById(1)).ReturnsAsync(product);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Deleted", okResult.Value);
            _productsServicesMock.Verify(x => x.Delete(product), Times.Once);
        }

    }
}
