using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface ICourierRepository : IRepository<Courier>
    {
        Task<int> RegisterAsync(Courier entity);
        Task<Courier> GetByUserNameAsync(string userName);
        Task ConfirmOrderReceived(int orderId);
        Task ConfirmOrderDelivered( int orderId);
    }
}
