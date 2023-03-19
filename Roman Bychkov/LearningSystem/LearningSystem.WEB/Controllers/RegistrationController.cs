
using LearningSystem.Contracts;
using LearningSystem.WEB.ValidationModels;

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
        public async Task<IActionResult> Registration()
        {
            ViewBag.Active = "registration";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            ViewBag.Active = "registration";

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
                return RedirectToAction("Login", "Login", model);
            }
            else
                return View(model);

        }
    }
}