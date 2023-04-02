﻿using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<int> RegisterAsync (User entity);
        Task<User> GetByUserNameAsync (string userName);
    }
}
