using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class UsersRepository : AbstractRepository<User>, IUsersRepository
    {
        private ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<User> GetUserByLoginPasswordAsync(string login, string password)
        {
            return (await _context.Set<User>().ToArrayAsync()).SingleOrDefault(e => e.UserName == login && e.Password == password);
        }

        public async Task<User> GetValueByСonditionAsync<T>(Func<User, T> valueSelector, T value)
        {
            return (await _context.Set<User>()
                .Include(u => u.Comments)
                .Include(u => u.LikeArticles)
                    .ThenInclude(a => a.Article)
                    .ThenInclude(c => c.Course)
                .Include(u => u.Courses)
                .ThenInclude(u => u.Articles)
                .ToArrayAsync()).SingleOrDefault(e => valueSelector(e).Equals(value));

        }

        public async Task AddImage(string path, string name)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == name);
            user.Image = path;
            await UpdateAsync(user);
        }

        public async Task<User> GetByIdAsync(int id, List<string> includeNodes)
        {
            var context = _context.Users;
            foreach (var includeNode in includeNodes)
            {
                context.Include(includeNode);
            }
            return await _context.Users.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<User> GetByName(string name)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == name);
        }
    }
}

