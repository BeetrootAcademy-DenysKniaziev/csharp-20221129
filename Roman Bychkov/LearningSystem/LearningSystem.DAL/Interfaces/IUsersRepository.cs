
namespace LearningSystem.DAL.Interfaces
{
    public  interface IUsersRepository:IRepository<User>
    {
        public Task<bool> IsValueExistAsync(Func<User, string> valueSelector, string value);
    }
}
