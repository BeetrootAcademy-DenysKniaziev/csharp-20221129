using LearningSystem.WEB.ValidationModels;

namespace LearningSystem.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private IUsersServices _service;
      
        public LoginController(ILogger<LoginController> logger, IUsersServices service)
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
                HttpC
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }

    }
}