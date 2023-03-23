using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface MyIAuthenticationService
    {
        Task<Person> MyAuthenticateAsync(string email, string password);
        string GenerateJwtToken(Person person);
    }
}
