using BLL.Services.Interfaces;
using Contracts.Models;
using DAL.Repository.Interface;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Find(Expression<Func<Product, bool>> predicate)
        {
            return await _productRepository.Find(predicate);
        }

        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task Delete(int id)
        {
            var entity = _productRepository.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Entity with specified ID not found.");
            }
            await _productRepository.Delete(await entity);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(int productId)
        {
            return await _productRepository.GetById(productId);
        }

        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }
    }
}
