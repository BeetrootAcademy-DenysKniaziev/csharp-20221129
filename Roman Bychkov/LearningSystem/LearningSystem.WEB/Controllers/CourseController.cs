using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.WEB.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoursesRepository _context;
        public CourseController(ILogger<HomeController> logger, ICoursesRepository context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("{id}/Lessons")]
        public async Task<IActionResult> Lesson(int id)
        {
            ViewBag.Active = "courses";
            return View(await _context.GetByIdAsync(id));
        }

        [Route("{id}/Lesson/{number}")]
        public async Task<IActionResult> Lesson(int id, int number)
        {
            ViewBag.Active = "courses";
            ViewBag.Number = number;
            return View(await _context.GetByIdAsync(id));
        }

    }
}