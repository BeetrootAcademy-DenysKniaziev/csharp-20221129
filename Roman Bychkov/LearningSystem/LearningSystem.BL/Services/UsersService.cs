namespace LearningSystem.BL.Services
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
