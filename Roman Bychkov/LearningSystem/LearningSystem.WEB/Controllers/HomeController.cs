using LearningSystem.DAL;
using LearningSystem.DAL.Interfaces;
using LearningSystem.WEB.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace LearningSystem.WEB.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoursesRepository _context;
        public HomeController(ILogger<HomeController> logger, ICoursesRepository db)
        {
            _logger = logger;
            _context = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Active = "courses";
            return View(await _context.GetAsync());
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