using LearningSystem.DAL;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.WEB.Controllers
{
    [Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        public CourseController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Route("{id}/Lessons")]
        public async Task<IActionResult> Lesson(int id)
        {
            ViewBag.Active = "courses";
            return View(await _db.Courses.Include(c=>c.Articles).SingleOrDefaultAsync(c => c.Id == id));
        }

        [Route("{id}/Lesson/{number}")]
        public async Task<IActionResult> Lesson(int id, int number)
        {
            ViewBag.Active = "courses";
            ViewBag.Number = number;
            return View(await _db.Courses.Include(c => c.Articles).SingleOrDefaultAsync(c => c.Id == id));
        }

    }
}