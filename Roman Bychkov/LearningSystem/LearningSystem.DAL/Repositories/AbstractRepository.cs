using LearningSystem.Contracts.Interfaces;
using LearningSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class AbstractRepository<T> : IRepository<T> where T : class, IEntityWithId
    {
        protected ApplicationDbContext _context;
        public AbstractRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T item)
        {
           await _context.Set<T>().AddAsync(item);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async virtual Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
        }

    }
}
