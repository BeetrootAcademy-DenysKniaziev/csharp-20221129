
using LearningSystem.Contracts;
using LearningSystem.WEB.ValidationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LearningSystem.WEB.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;
        private IUsersServices _context;
        public RegistrationController(ILogger<RegistrationController> logger, IUsersServices context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Authorisation()
        {
            ViewBag.Active = "authorisation";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Authorisation(RegistrationModel model)
        {
            ViewBag.Active = "authorisation";

            if (await _context.IsValueExistAsync(u => u.Email, model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Користувач з такою поштою вже існує");
                return View(model);
            }
            if (await _context.IsValueExistAsync(u => u.UserName, model.UserName))
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
               


                await _context.AddAsync(user);
                //TODO: add logic after succesful registration
                return RedirectToAction("Authorisation", "Authorisation", model);
            }
            else
                return RedirectToAction("Authorisation", "Authorisation", model);

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            ViewBag.Active = "authorisation";

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
                return RedirectToAction("Authorisation", "Authorisation", redirectionModel);
            }
        }

    }
}