
using LearningSystem.Contracts.Interfaces;

namespace LearningSystem.DAL.Interfaces
{
    public  interface IRepository<T> where T : class, IEntityWithId
    {
        public Task AddAsync(T item);
        public Task UpdateAsync(T item);
        public Task DeleteAsync(T item);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
    }
}
