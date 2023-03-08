
using Lesson36.Dal.Repositories;

namespace Lesson36.BL.Services
{
    public class ProductsServices : IProductsServices
    {
        private IProductsRepository _productsRepository;
        public ProductsServices(IProductsRepository rep)
        {
            _productsRepository = rep;
        }
        public async Task Add(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Invalid product name");
            if (product.Price <= 0)
                throw new ArgumentException("Invalid product price");
            if (string.IsNullOrWhiteSpace(product.Description))
                throw new ArgumentException("Invalid product description");
            if (string.IsNullOrWhiteSpace(product.Description))
                throw new ArgumentException("Invalid product description");
            if (product.Price < product.DiscountedPrice)
                throw new ArgumentException("Invalid product discount price");

            await _productsRepository.Add(product);
        }

        public async Task Delete(Product product)
        {
            if (product is null)
                throw new ArgumentNullException("Product does not exist");
            await _productsRepository.Delete(product);
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _productsRepository.Get();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productsRepository.GetById(id);
        }

        public async Task Update(Product product, int id)
        {
            var updateProduct = await GetById(id);
            if (updateProduct is null)
                throw new ArgumentNullException("Product does not exist");
            else
            {
                updateProduct.Price = product.Price > 0 ? product.Price : updateProduct.Price;
                updateProduct.Description = product.Description ?? updateProduct.Description;
                updateProduct.DiscountedPrice = product.DiscountedPrice > 0 ? product.DiscountedPrice : updateProduct.DiscountedPrice;
                if (updateProduct.DiscountedPrice >= updateProduct.Price)
                    throw new ArgumentException("Invalid discount price");
                updateProduct.Name = product.Name ?? updateProduct.Name;
            }
            await _productsRepository.Update(updateProduct);
        }
    }
}
