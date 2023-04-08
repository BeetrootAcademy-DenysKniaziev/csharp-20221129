
using LearningSystem.WEB.Models;
using System.Diagnostics;

namespace LearningSystem.WEB.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoursesService _service;
        public HomeController(ILogger<HomeController> logger, ICoursesService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Active = "courses";
            return View(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SearchCourse(string substring)
        {
            if (string.IsNullOrEmpty(substring))
                return RedirectToAction("Index");
            else
            {
                ViewBag.Search = substring;
                return View("Index", (await _service.GetAllAsync()).Where(a => a.CourseName.ToLower().Contains(substring.ToLower()) || a.Description.ToLower().Contains(substring.ToLower())));
            }
        }
        public IActionResult Privacy()
        {
            ViewBag.Active = "privacy";
            return View();
        }
        public IActionResult Oops(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}