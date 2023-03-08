
namespace Lesson36.Dal.Repositories
{
    public interface IRepository<T>
    {
        public Task Add(T item);
        public Task Update(T item);
        public Task Delete(T item);
        public Task<IEnumerable<T>> Get();
        public Task<T> GetById(int id);
    }
}
