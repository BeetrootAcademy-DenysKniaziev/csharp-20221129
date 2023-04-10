﻿using Contracts.Models;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> GetByUserNameAsync(string userName)
        {
            return await _context.Admin.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _context.Admin.ToListAsync();
        }

        public async Task<Admin> GetById(int id)
        {
            return await _context.Admin.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Admin>> Find(Expression<Func<Admin, bool>> predicate)
        {
            return await _context.Admin.Where(predicate).ToArrayAsync();
        }

        public async Task Add(Admin entity)
        {
            await _context.Admin.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Admin entity)
        {
            _context.Admin.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Admin entity)
        {
            _context.Admin.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
