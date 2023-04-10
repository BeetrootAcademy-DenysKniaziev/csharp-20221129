using Contracts.Models;

namespace DAL.Repository.Interface
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<Admin> GetByUserNameAsync(string userName);
    }
}

