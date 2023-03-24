
namespace LearningSystem.BLL.Interfaces
{
    public interface IUsersServices:IServices<User>
    {
        public Task<User> GetValueByСonditionAsync(Func<User, string> valueSelector, string value);
        public Task<User> GetUserByLoginPasswordAsync(string login, string password);
       
    }
}
