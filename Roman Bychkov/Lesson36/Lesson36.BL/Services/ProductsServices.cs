
using Lesson36.Dal.Repositories;

namespace Lesson36.BL.Services
{
    public class ProductsServices:IProductsServices
    {
        private IProductsRepository _productsRepository;
        public ProductsServices(IProductsRepository rep)
        {
            _productsRepository = rep;
        }
        public void Add(Product product)
        {
            _productsRepository.Add(product);
        }

        public void Delete(Product person)
        {
            _productsRepository.Delete(person);
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _productsRepository.Get();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productsRepository.GetById(id);
        }

        public void Update(Product person)
        {
            _productsRepository.Update(person);
        }
    }
}
