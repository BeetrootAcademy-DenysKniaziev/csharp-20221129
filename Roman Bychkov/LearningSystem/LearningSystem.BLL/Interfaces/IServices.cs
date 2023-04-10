

namespace LearningSystem.BLL.Interfaces
{
    public interface IServices<T> where T : class, IEntityWithId
    {
        public Task AddAsync(T item);
        public Task UpdateAsync(T item);
        public Task DeleteAsync(T item);
        public Task<IEnumerable<T>> GetAsync();
        public Task<T> GetByIdAsync(int id);
    }
}
