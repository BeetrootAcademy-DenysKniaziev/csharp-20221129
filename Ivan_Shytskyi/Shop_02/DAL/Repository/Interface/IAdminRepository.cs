﻿using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<int> RegisterAsync(Admin entity);
        Task<Admin> GetByUserNameAsync(string userName);
    }
}

