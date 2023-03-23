using Lesson36.Contracts;
using System.Threading.Tasks;

namespace Lesson36.Bll.Services
{
    public interface IUserService
    {
        Task<int> RegisterAsync(User user);

        Task<User> GetByUsernameAsync(string userName);
    }
}
