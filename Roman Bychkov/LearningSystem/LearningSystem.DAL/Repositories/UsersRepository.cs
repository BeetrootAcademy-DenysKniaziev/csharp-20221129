
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class UsersRepository : AbstractRepository<User>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<User> GetUserByLoginPasswordAsync(string login, string password)
        {
            return (await _context.Set<User>().ToArrayAsync()).SingleOrDefault(e => e.UserName == login && e.Password == password);
        }

        public async Task<User> GetValueByСonditionAsync(Func<User, string> valueSelector, string value)
        {
            return (await _context.Set<User>().Include(u => u.Comments).Include(u => u.LikeArticles).ToArrayAsync()).SingleOrDefault(e => valueSelector(e) == value);
        }
    }
}

