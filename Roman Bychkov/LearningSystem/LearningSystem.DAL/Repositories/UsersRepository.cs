
namespace LearningSystem.DAL.Repositories
{
    public class UsersRepository:AbstractRepository<User>,IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context):base(context)
        { }

    }
}

