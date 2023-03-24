using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

namespace LearningSystem.BLL.Services
{
    public class UsersService : IUsersServices
    {
        private IUsersRepository _context;
        public UsersService(IUsersRepository context)
        {
            _context = context;
        }
        public async Task AddAsync(User item)
        {

            item.Password = SHA256Managed(item.Password);
            await _context.AddAsync(item);
        }
        private string SHA256Managed(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = new SHA256Managed().ComputeHash(passwordBytes);
            string hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash.Remove(50);
        }
        public async Task DeleteAsync(User item)
        {
            await _context.DeleteAsync(item);
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.GetAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async Task UpdateAsync(User item)
        {
            await _context.UpdateAsync(item);
        }

        public async Task<User> GetValueByСonditionAsync(Func<User, string> valueSelector, string value)
        {
            return await _context.GetValueByСonditionAsync(valueSelector, value);
        }

        public async Task<User> GetUserByLoginPasswordAsync(string login, string password)
        {
            if(!string.IsNullOrEmpty(password))
                password = SHA256Managed(password);
            return await _context.GetUserByLoginPasswordAsync(login, password);
        }

       
    }
}
