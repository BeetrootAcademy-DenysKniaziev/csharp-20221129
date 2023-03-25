
namespace LearningSystem.DAL.Interfaces
{
    public  interface IUsersRepository:IRepository<User>
    {
       public Task<User> GetValueByСonditionAsync<T>(Func<User, T> valueSelector, T value);
       public Task<User> GetUserByLoginPasswordAsync(string login, string password);
       public Task AddImage(string path, string name);
    }
}
