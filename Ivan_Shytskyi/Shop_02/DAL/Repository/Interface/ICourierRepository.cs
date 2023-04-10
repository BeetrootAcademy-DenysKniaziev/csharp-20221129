using Contracts.Models;

namespace DAL.Repository.Interface
{
    public interface ICourierRepository : IRepository<Courier>
    {
        Task<Courier> GetByUserNameAsync(string userName);
        Task ConfirmOrderReceived(int orderId);
        Task ConfirmOrderDelivered( int orderId);
    }
}
