using Contracts.Models;

namespace BLL.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<User> GetByUserNameAsync(string userName);
    }
}
