
using LearningSystem.Contracts;
using LearningSystem.WEB.ValidationModels;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.WEB.Controllers
{
    public class AauthorisationController : Controller
    {
        private readonly ILogger<AauthorisationController> _logger;
        private IUsersServices _context;
        public AauthorisationController(ILogger<AauthorisationController> logger, IUsersServices context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            ViewBag.Active = "authorisation";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Password = model.Password,
                    Image = "not found"
                };
                await _context.AddAsync(user);
                return View(model);
            }
            else
            {
              return View(model);
            }
        }
       
    }
}