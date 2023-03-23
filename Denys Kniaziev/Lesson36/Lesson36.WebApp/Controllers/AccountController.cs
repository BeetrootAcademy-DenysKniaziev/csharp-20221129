using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Lesson36.Bll.Services;
using Lesson36.Contracts;
using Lesson36.WebApp.Models.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lesson36.WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IUserService UserService { get; }
        public IConfiguration Configuration { get; }

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            UserService = userService;
            Configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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

            HttpContext.Session.SetString("Token", jwtToken);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            using var hash = new HMACSHA512();

            User user = new User
            {
                UserName = registerUser.UserName,
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password)),
                PasswordSalt = hash.Key
            };
            var userName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);

            await UserService.RegisterAsync(user);

            return await Login(new LoginUser
            {
                UserName = registerUser.UserName,
                Password = registerUser.Password
            });
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}