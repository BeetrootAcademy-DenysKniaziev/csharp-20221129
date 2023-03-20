
using LearningSystem.Contracts;
using LearningSystem.WEB.ValidationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LearningSystem.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private IUsersServices _context;
        public LoginController(ILogger<LoginController> logger, IUsersServices context)
        {
            _logger = logger;
            _context = context;
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
            
            if (!await _context.IsValueExistAsync(u => u.UserName, model.UserName))
            {
                ModelState.AddModelError(nameof(model.UserName), "Такого аккаунта не існує");
                return View(model);
            }
            if (!await _context.IsValidPassword(model.UserName, model.Password))
            {
                ModelState.AddModelError(nameof(model.Password), "Пароль не вірний");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var redirectionModel = new RegistrationModel
                {
                    UserName = model.UserName,
                    Password = model.Password
                };
                return View(model);
            }
        }

    }
}