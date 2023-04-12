using Contracts.Models;
using System.Linq.Expressions;

namespace BLL.Services.Interfaces
{
    public interface IAdminService : IService<Admin>
    {
        Task<Admin> GetByUserNameAsync(string userName);
    }
}
