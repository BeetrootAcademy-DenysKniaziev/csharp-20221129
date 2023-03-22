using LearningSystem.WEB.ValidationModels;
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
        private IConfiguration _configuration;
        public RegistrationController(ILogger<RegistrationController> logger, IUsersServices service, IConfiguration configuration)
        {
            _logger = logger;
            _service = service;
            _configuration = configuration;
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
                //    new Claim(ClaimTypes.Name, user.Password),
                //    new Claim(ClaimTypes.Email, user.Email)
                //};

                //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt").Value));
                //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //var token = new JwtSecurityToken(
                //    issuer: null,
                //    audience: null,
                //    claims: claims,
                //    expires: DateTime.Now.AddDays(7),
                //    signingCredentials: creds
                //);
                //Response.Cookies.Append("jwt_token", new JwtSecurityTokenHandler().WriteToken(token));
                //return Ok(new JwtSecurityTokenHandler().WriteToken(token));

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
              
                return RedirectToAction("Login", "Login", model);
            }
            else
                return View(model);

        }
    }
}