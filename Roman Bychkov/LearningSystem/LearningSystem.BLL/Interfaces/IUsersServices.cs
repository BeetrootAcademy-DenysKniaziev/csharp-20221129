using System.IO;
using Microsoft.AspNetCore.Http;

namespace LearningSystem.BLL.Interfaces
{
    public interface IUsersServices:IServices<User>
    {
        public Task<User> GetValueByСonditionAsync<T>(Func<User, T> valueSelector, T value);
        public Task<User> GetUserByLoginPasswordAsync(string login, string password);
        public Task<string> AddImage(string nameFolder, string name, IFormFile file);

        public Task<User> GetByName(string name);

    }
}
