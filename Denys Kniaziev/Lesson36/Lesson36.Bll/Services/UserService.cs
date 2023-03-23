using Lesson36.Contracts;
using Lesson36.Dal.Repositories;
using System.Threading.Tasks;

namespace Lesson36.Bll.Services
{
    public class UserService : IUserService
    {
        private IUserRepository Repository { get; }

        public UserService(IUserRepository repository)
        {
            Repository = repository;
        }

        public Task<User> GetByUsernameAsync(string userName) =>
            Repository.GetByUsernameAsync(userName);

        public Task<int> RegisterAsync(User user) =>
            Repository.RegisterAsync(user);
    }
}
