using LearningSystem.WEB.ValidationModels;

namespace LearningSystem.WEB.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private IUsersServices _service;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUsersServices service)
        {
            _logger = logger;
            _service = service;
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
            Response.Cookies.Delete("user_login");
            Response.Cookies.Delete("user_pass");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            ViewBag.Active = "login";


            if (!await _service.IsValueExistAsync(u => u.UserName, model.UserName))
            {
                ModelState.AddModelError(nameof(model.UserName), "Такого аккаунта не існує");
                return View(model);
            }
            if ((await _service.GetUserByLoginPassword(model.UserName, model.Password)) == null)
            {
                ModelState.AddModelError(nameof(model.Password), "Пароль не вірний");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                //var token = GenerateJwtToken(await _service.GetUserByLoginPassword(model.UserName, model.Password));
                Response.Cookies.Append("user_login", model.UserName, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)
                });
                Response.Cookies.Append("user_pass", model.Password, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)
                });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }

    }
}