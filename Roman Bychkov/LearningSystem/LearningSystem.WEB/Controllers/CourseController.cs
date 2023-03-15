using LearningSystem.DAL;
using LearningSystem.WEB.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace LearningSystem.WEB.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        public CourseController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Route("Lesson/{id}")]
        public async Task<IActionResult> Lesson(int id)
        {
            ViewBag.Active = "courses";
            return View(new int[] {1,2,3,4,5});
        }

    }
}