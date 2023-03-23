using Lesson36.Bll.Services;
using Lesson36.Contracts;
using Lesson36.WebApp.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Lesson36.WebApp.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        public IUserService UserService { get; }
        public IConfiguration Configuration { get; }

        public AuthApiController(IUserService userService, IConfiguration configuration)
        {
            UserService = userService;
            Configuration = configuration;
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var user = await UserService.GetByUsernameAsync(loginUser.UserName);

            if (user == null)
            {
                return Unauthorized();
            }

            using var hash = new HMACSHA512(user.PasswordSalt);

            var passwordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));

            if (!passwordHash.SequenceEqual(user.PasswordHash))
            {
                return Unauthorized();
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = "myapp",
                Audience = "myapp",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt_Key"])),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return Ok(jwtToken);
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            using var hash = new HMACSHA512();

            User user = new User
            {
                UserName = registerUser.UserName,
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password)),
                PasswordSalt = hash.Key
            };

            await UserService.RegisterAsync(user);

            return Created(nameof(Login), user.UserName);
        }
    }
}
