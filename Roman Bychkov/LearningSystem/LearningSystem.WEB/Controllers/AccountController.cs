using LearningSystem.WEB.ValidationModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearningSystem.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private IUsersServices _service;
        private IConfiguration _configuration;

        public AccountController(ILogger<AccountController> logger, IUsersServices service, IConfiguration configuration)
        {
            _logger = logger;
            _service = service;
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            ViewBag.Active = "login";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            ViewBag.Active = "login";


            if (await _service.GetValueByСonditionAsync(u => u.UserName, model.UserName) is null)
            {
                ModelState.AddModelError(nameof(model.UserName), "Такого аккаунта не існує");
                return View(model);
            }
            var user = await _service.GetUserByLoginPasswordAsync(model.UserName, model.Password);
            if (user is null)
            {
                ModelState.AddModelError(nameof(model.Password), "Пароль не вірний");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                ////var token = GenerateJwtToken(await _service.GetUserByLoginPassword(model.UserName, model.Password));
                //Response.Cookies.Append("user_login", model.UserName, new CookieOptions
                //{
                //    Expires = DateTime.Now.AddDays(7)
                //});
                //Response.Cookies.Append("user_pass", model.Password, new CookieOptions
                //{
                //    Expires = DateTime.Now.AddDays(7)
                //});
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
{
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                }),
                    Expires = DateTime.UtcNow.AddDays(3),
                    Issuer = "myapp",
                    Audience = "myapp",
                    SigningCredentials = new SigningCredentials(
                     new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt_Key"])),
                     SecurityAlgorithms.HmacSha512Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                HttpContext.Session.SetString("Token", jwtToken);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            ViewBag.Active = "registration";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            ViewBag.Active = "registration";

            if (await _service.GetValueByСonditionAsync(u => u.Email, model.Email) != null)
            {
                ModelState.AddModelError(nameof(model.Email), "Користувач з такою поштою вже існує");
                return View(model);
            }
            if (await _service.GetValueByСonditionAsync(u => u.UserName, model.UserName) != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "Користувач з таким іменем вже існує");
                return View(model);
            }


            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Password = model.Password,
                };

                //Cookies
                //Response.Cookies.Append("user_login", model.UserName, new CookieOptions
                //{
                //    Expires = DateTime.Now.AddDays(7)
                //});
                //Response.Cookies.Append("user_pass", model.Password, new CookieOptions
                //{
                //    Expires = DateTime.Now.AddDays(7)
                //});
                //
                await _service.AddAsync(user);
                return RedirectToAction("Login", "Account", new LoginModel() { UserName = model.UserName });
            }
            else
                return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Profile(string name)
        {
            return View(await _service.GetValueByСonditionAsync(u=>u.UserName,name));
        }

    }
}