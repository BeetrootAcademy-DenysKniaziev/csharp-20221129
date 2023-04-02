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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUserNameAsync(string userName) 
        {
            return await _context.User.FirstOrDefaultAsync(u =>  u.UserName  == userName);
        }
        public async Task<int> RegisterAsync(User user)
        {
           var res = await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return res.Entity.Id;
        }

        public async Task<IEnumerable<User>> Find(Expression<Func<User, bool>> predicate)
        {
            return await _context.User.Where(predicate).ToArrayAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Add(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
