//using BAL.Interfaces;
using Contracts;
using DAL.Interfaces;
using ExchangeMarket.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MarketContext Context;

        public Repository(MarketContext context)
        {
            Context = context;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

    }
}




//using Contracts;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Runtime.InteropServices;

//namespace Homework35.DAL.Repositories
//{
//    public class Repository : IPersonRepository
//    {
//        private MarketContext _marketContext;
//        public Repository(MarketContext context) 
//        {
//            _marketContext = context; 
//        }


//        public async Task<IEnumerable<Person>> GetAll()
//        {
//            return await _marketContext.Persons.ToListAsync();
//        }
//        public async Task<Person> GetById(int id)
//        {
//            return await _marketContext.Persons.FirstOrDefaultAsync(p => p.ID == id);
//        }
//        public async Task Add(Person person)
//        {
//            await _marketContext.AddAsync(person);
//            await _marketContext.SaveChangesAsync();
//        }
//        public async Task Update(Person person)
//        {
//            _marketContext.Update(person);
//            await _marketContext.SaveChangesAsync();
//        }
//        public async Task Delete(Person person)
//        {
//            _marketContext.Remove(person);
//            await _marketContext.SaveChangesAsync();
//        }
//    }
//}
