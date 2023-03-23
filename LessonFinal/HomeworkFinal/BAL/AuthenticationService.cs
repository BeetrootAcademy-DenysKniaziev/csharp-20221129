using BAL.Interfaces;
using BAL.Services;
using Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class AuthenticationService : MyIAuthenticationService
    {
        private readonly IPersonService _personService;
        private readonly IPasswordHasher<Person> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IPersonService personService, IPasswordHasher<Person> passwordHasher, IConfiguration configuration)
        {
            _personService = personService;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<Person> MyAuthenticateAsync(string email, string password)
        {
            var person = await _personService.GetPersonByEmailAsync(email);

            if (person == null)
                return null;

            if (_passwordHasher.VerifyHashedPassword(person, person.PasswordHash, password) == PasswordVerificationResult.Success)
                return person;

            return null;
        }

        public string GenerateJwtToken(Person person)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, person.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, person.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
