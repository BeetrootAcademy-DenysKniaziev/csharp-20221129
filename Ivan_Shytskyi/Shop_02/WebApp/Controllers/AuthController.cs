using BLL.Services;
using BLL.Services.Interfaces;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AuthController : ControllerBase
    {
        public IUserService UserService { get; }
        public IAdminService AdminService { get; }
        public ICourierService CourierService { get; }
        public IConfiguration Configuration { get; }
        public AuthController(IUserService userService, IAdminService adminService, ICourierService courierService, IConfiguration configuration)
        {
            UserService = userService;
            AdminService = adminService;
            CourierService = courierService;
            Configuration = configuration;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            using var hash = new HMACSHA512();

            User user = new User
            {
                UserName = userRegister.UserName,
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(userRegister.Password)),
                PasswordSalt = hash.Key
            };

            await UserService.RegisterAsync(user);

            return Created(nameof(Login), user.UserName);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var user = await UserService.GetByUserNameAsync(loginUser.UserName);

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
    }
}
