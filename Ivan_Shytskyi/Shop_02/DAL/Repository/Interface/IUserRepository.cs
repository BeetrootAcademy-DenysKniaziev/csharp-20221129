using Contracts.Models;

namespace DAL.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserNameAsync (string userName);
    }
}
