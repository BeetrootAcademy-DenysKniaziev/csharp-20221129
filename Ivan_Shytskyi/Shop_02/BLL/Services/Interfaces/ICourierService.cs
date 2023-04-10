using Contracts.Models;
using System;
using System.Linq.Expressions;

namespace BLL.Services.Interfaces
{
    public interface ICourierService : IService<Courier>
    {
        Task<Courier> GetByUserNameAsync(string userName);
        Task ConfirmOrderReceived( int orderId);
        Task ConfirmOrderDelivered( int orderId);
    }
}
