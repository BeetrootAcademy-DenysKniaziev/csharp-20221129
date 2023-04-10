using Contracts.Models;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class StoregeRepository : IStoregeRepository
    {
        private readonly AppDbContext _context;

        public StoregeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Storege>> Find(Expression<Func<Storege, bool>> predicate)
        {
            return await _context.Storege.Where(predicate).ToArrayAsync();
        }

        public async Task<IEnumerable<Storege>> GetAll()
        {
            return await _context.Storege.Include(s => s.Products).ToListAsync();
        }

        public async Task<Storege> GetById(int id)
        {
            return await _context.Storege.Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Add(Storege entity)
        {
            await _context.Storege.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Storege entity)
        {
            _context.Storege.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Storege entity)
        {
            _context.Storege.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
