using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.WEB.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoursesService _service;
        public CourseController(ILogger<HomeController> logger, ICoursesService service)
        {
            _logger = logger;
            _service = service;
        }

        [Route("{id}/Lessons")]
        public async Task<IActionResult> Lesson(int id)
        {
            ViewBag.Active = "courses";
            return View(await _service.GetByIdAsync(id));
        }

        [Route("{id}/Lesson/{number}")]
        public async Task<IActionResult> Lesson(int id, int number)
        {
            ViewBag.Active = "courses";
            ViewBag.Number = number;
            return View(await _service.GetByIdAsync(id));
        }

    }
}