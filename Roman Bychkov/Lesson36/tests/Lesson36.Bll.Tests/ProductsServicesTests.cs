
namespace Lesson36.Bl.Tests
{
    public class ProductsServicesTests
    {
        private readonly Mock<IProductsRepository> _repositoryMock = new Mock<IProductsRepository>();
        private readonly IProductsServices _productsServices;

        public ProductsServicesTests()
        {
            _productsServices = new ProductsServices(_repositoryMock.Object);
        }

        [Fact]
        public async Task Add_ProductWithValidData_ShouldCallAddMethodOnRepository()
        {
            // Arrange
            var product = new Product
            {
                Name = "Test Product",
                Price = 10.0m,
                Description = "Test description",
                DiscountedPrice = 5.0m
            };

            // Act
            await _productsServices.Add(product);

            // Assert
            _repositoryMock.Verify(r => r.Add(product), Times.Once);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task Add_ProductWithInvalidName_ShouldThrowArgumentException(string productName)
        {
            // Arrange
            var product = new Product
            {
                Name = productName,
                Price = 10.0m,
                Description = "Test description",
                DiscountedPrice = 5.0m
            };

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _productsServices.Add(product));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public async Task Add_ProductWithInvalidPrice_ShouldThrowArgumentException(decimal price)
        {
            // Arrange
            var product = new Product
            {
                Name = "Test Product",
                Price = price,
                Description = "Test description",
                DiscountedPrice = 5.0m
            };

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _productsServices.Add(product));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task Add_ProductWithInvalidDescription_ShouldThrowArgumentException(string description)
        {
            // Arrange
            var product = new Product
            {
                Name = "Test Product",
                Price = 10.0m,
                Description = description,
                DiscountedPrice = 5.0m
            };

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _productsServices.Add(product));
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(11)]
        [InlineData(10.2)]
        public async Task Add_ProductWithInvalidDiscountedPrice_ShouldThrowArgumentException(decimal discountedPrice)
        {
            // Arrange
            var product = new Product
            {
                Name = "Test Product",
                Price = 10.0m,
                Description = "Test description",
                DiscountedPrice = discountedPrice
            };

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _productsServices.Add(product));
        }

        [Fact]
        public async Task Delete_Product_ShouldCallDeleteMethodOnRepository()
        {
            // Arrange
            var product = new Product { Id = 1 };

            // Act
            await _productsServices.Delete(product);

            // Assert
            _repositoryMock.Verify(r => r.Delete(product), Times.Once);
        }

        [Fact]
        public async Task Delete_NullProduct_ShouldThrowArgumentNullException()
        {
            // Arrange + Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _productsServices.Delete(null));
        }
    }
}
