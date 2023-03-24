
namespace LearningSystem.DAL.Interfaces
{
    public  interface IUsersRepository:IRepository<User>
    {
       public Task<User> GetValueByСonditionAsync(Func<User, string> valueSelector, string value);
       public Task<User> GetUserByLoginPasswordAsync(string login, string password);

    }
}
