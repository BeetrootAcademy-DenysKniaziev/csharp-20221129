﻿using Contracts.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<int> RegisterAsync(User entity);
        Task<User> GetByUserNameAsync(string userName);
        //Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        //Task<IEnumerable<TEntity>> GetAll();
        //Task<TEntity> GetById(int id);
        //Task Add(TEntity entity);
        //Task Update(TEntity entity);
        //Task Delete(int id);
    }
}
