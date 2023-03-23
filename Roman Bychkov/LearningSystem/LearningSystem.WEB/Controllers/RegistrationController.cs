using LearningSystem.WEB.ValidationModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearningSystem.WEB.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;
        private IUsersServices _service;
        private readonly JWTSettings _options;
        private SignInManager<User> _signInManager;
        public RegistrationController(ILogger<RegistrationController> logger, IUsersServices service, IOptions<JWTSettings> optAccess)
        {
            _logger = logger;
            _service = service;
            _options = optAccess.Value;
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

            if (await _service.IsValueExistAsync(u => u.Email, model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Користувач з такою поштою вже існує");
                return View(model);
            }
            if (await _service.IsValueExistAsync(u => u.UserName, model.UserName))
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

                //TODO: add logic after succesful registration
                //var claims = new List<Claim>
                //{
                //        new Claim(ClaimTypes.Name, user.UserName),
                //        new Claim(ClaimTypes.Email, user.Email)
                //};

                //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
                //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //var jwt = new JwtSecurityToken(

                //    issuer: _options.Issuer,
                //    audience: _options.Audience,
                //    claims: claims,
                //    expires: DateTime.UtcNow.AddMinutes(35),
                //    notBefore: DateTime.UtcNow,
                //    signingCredentials: creds);
                //var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                //// Сохранение токена в Cookies
                //Response.Cookies.Append("jwt", token, new CookieOptions
                //{
                //    HttpOnly = true,
                //    Secure = true,
                //    SameSite = SameSiteMode.Strict
                //});

                //var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, isPersistent: false, lockoutOnFailure: false);
                //if (signInResult.Succeeded)
                //{
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Невірний логін або пароль");
                //    return View(model);
                //}
                //Cookies
                Response.Cookies.Append("user_login", model.UserName, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)
                });
                Response.Cookies.Append("user_pass", model.Password, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)
                });
                //
                await _service.AddAsync(user);
                return RedirectToAction("Index", "Home", model);
            }
            else
                return View(model);

        }
    }
}