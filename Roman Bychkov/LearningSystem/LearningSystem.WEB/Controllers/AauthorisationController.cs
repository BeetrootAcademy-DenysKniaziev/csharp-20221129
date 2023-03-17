using LearningSystem.DAL;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.WEB.Controllers
{
    [Route("[controller]")]
    public class AauthorisationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        public AauthorisationController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

      
        public async Task<IActionResult> Registration()
        {
            ViewBag.Active = "authorisation";
            return View();
        }
    }
}