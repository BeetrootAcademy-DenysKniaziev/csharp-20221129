using Contracts.Models;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Product)
                .ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<IEnumerable<Order>> Find(Expression<Func<Order, bool>> predicate)
        {
            return await _dbContext.Orders.Where(predicate).ToArrayAsync();
        }
        public async Task Add(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
