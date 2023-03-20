﻿
namespace LearningSystem.BLL.Interfaces
{
    public interface IUsersServices:IServices<User>
    {
        public Task<bool> IsValueExistAsync(Func<User, string> valueSelector, string value);
        public Task<User> GetUserByLoginPassword(string login, string password);
       
    }
}
