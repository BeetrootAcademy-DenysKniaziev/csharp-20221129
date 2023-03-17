
namespace LearningSystem.DAL.Repositories
{
    public class UsersRepository:AbstractRepository<User>
    {
        public UsersRepository(ApplicationDbContext context):base(context)
        { }

    }
}

