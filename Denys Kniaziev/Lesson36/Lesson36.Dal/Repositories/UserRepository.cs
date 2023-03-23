using Lesson36.Contracts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lesson36.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext Context { get; }

        public UserRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<int> RegisterAsync(User user)
        {
            var result = await Context.AddAsync(user);
            await Context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<User> GetByUsernameAsync(string userName)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
