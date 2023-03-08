

namespace Lesson36.Dal.Repositories
{
    public interface IProductsRepository
    {
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public Task<IEnumerable<Product>> Get();
        public Task<Product> GetById(int id);
    }
}
