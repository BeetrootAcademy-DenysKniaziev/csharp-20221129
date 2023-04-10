using Contracts.Models;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class СourierRepository : ICourierRepository
    {
        private readonly AppDbContext _context;

        public СourierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Courier> GetByUserNameAsync(string userName)
        {
            return await _context.Сourier.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<IEnumerable<Courier>> Find(Expression<Func<Courier, bool>> predicate)
        {
            return  await _context.Сourier.Where(predicate).ToArrayAsync();
        }

        public async Task<IEnumerable<Courier>> GetAll()
        {
            return await _context.Сourier.ToListAsync();
        }

        public async Task<Courier> GetById(int id)
        {
            return await _context.Сourier.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Add(Courier courier)
        {
            _context.Сourier.Add(courier);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Courier courier)
        {
            _context.Сourier.Update(courier);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Courier courier)
        {
            _context.Сourier.Remove(courier);
            await _context.SaveChangesAsync();
        }

        public async Task ConfirmOrderReceived(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            order.IsReceived = true;
            await _context.SaveChangesAsync();
        }

        public async Task ConfirmOrderDelivered(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            order.IsDelivered = true;
            await _context.SaveChangesAsync();
        }
    }
}
