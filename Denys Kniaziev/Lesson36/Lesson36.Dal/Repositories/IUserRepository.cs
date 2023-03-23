using Lesson36.Contracts;
using System.Threading.Tasks;

namespace Lesson36.Dal.Repositories
{
    public interface IUserRepository
    {
        Task<int> RegisterAsync(User user);

        Task<User> GetByUsernameAsync(string userName);
    }
}
