using Contracts.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services.Interfaces
{
    public interface IMyAuthenticationService
    {
        Task<User> MyAuthenticateAsync(string email, string password);
        Task LogoutAsync();
        Task<IdentityResult> RegisterAsync(User user, string password);
    }
}
