using Contracts.Models;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class СourierRepository : ICourierRepository<Сourier>
    {
        private readonly AppDbContext _context;

        public СourierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Сourier>> Find(Expression<Func<Сourier, bool>> predicate)
        {
            return  _context.Сourier.Where(predicate);
        }

        public async Task<IEnumerable<Сourier>> GetAll()
        {
            return await _context.Сourier.ToListAsync();
        }

        public async Task<Сourier> GetById(int id)
        {
            return await _context.Сourier.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Add(Сourier courier)
        {
            _context.Сourier.Add(courier);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Сourier courier)
        {
            _context.Сourier.Update(courier);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Сourier courier)
        {
            _context.Сourier.Remove(courier);
            await _context.SaveChangesAsync();
        }

        public async Task ConfirmOrderReceived(/*int courierId,*/ int orderId)
        {
            var order = _context.Orders.Find(orderId);
            order.IsReceived = true;
            //order.СourierId = courierId;
            await _context.SaveChangesAsync();
        }

        public async Task ConfirmOrderDelivered(/*int courierId,*/ int orderId/*, int userId*/)
        {
            var order = _context.Orders.Find(orderId);
            order.IsDelivered = true;
            //order.СourierId = courierId;
            //order.UserId = userId;
            await _context.SaveChangesAsync();
        }
    }
}
