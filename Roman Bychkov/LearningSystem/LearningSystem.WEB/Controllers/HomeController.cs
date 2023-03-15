using LearningSystem.DAL;
using LearningSystem.WEB.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace LearningSystem.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Active = "courses";
            return View(await _db.Courses.ToListAsync());
        }

        public IActionResult Privacy()
        {
            ViewBag.Active = "privacy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}