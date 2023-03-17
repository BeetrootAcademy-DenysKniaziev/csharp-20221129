
namespace LearningSystem.DAL.Interfaces
{
    public  interface IRepository<T> where T : class
    {
        public Task AddAsync(T item);
        public Task UpdateAsync(T item);
        public Task DeleteAsync(T item);
        public Task<IEnumerable<T>> GetAsync();
        public Task<T> GetByIdAsync(int id);
    }
}
