using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

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
          

            // Generate a 128-bit salt using a sequence of
            // cryptographically strong random bytes.
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: item.Password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            item.Password = hashed;
            await _context.AddAsync(item);
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
            await  _context.UpdateAsync(item);
        }
    }
}
