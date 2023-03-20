
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class UsersRepository:AbstractRepository<User>,IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context):base(context)
        { }

        public async Task<bool> IsValidPassword(string login, string password)
        {
           return (await _context.Set<User>().ToArrayAsync()).Any(e => e.UserName==login && e.Password == password);
        }

        public async Task<bool> IsValueExistAsync(Func<User, string> valueSelector, string value)
        {
           return (await _context.Set<User>().ToArrayAsync()).Any(e => valueSelector(e) == value);
        }
    }
}

