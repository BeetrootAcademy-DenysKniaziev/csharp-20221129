using LearningSystem.WEB.ValidationModels;
using Microsoft.AspNetCore.Authorization;

namespace LearningSystem.WEB.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoursesService _coursesService;
        private IUsersServices _usersService;
        private ILikeArticleService _arcticlesLikeService;
        private IArcticlesService _arcticlesService;
        public CourseController(ILogger<HomeController> logger, ICoursesService service, IUsersServices usersServices,
            ILikeArticleService articleLikeService, IArcticlesService arcticlesService)
        {
            _logger = logger;
            _coursesService = service;
            _usersService = usersServices;
            _arcticlesLikeService = articleLikeService;
            _arcticlesService = arcticlesService;
        }

        [Route("{id}/Lessons")]
        public async Task<IActionResult> Lesson(int id)
        {
            ViewBag.Active = "courses";
            return View(await _coursesService.GetByIdAsync(id));
        }

        [Route("{id}/Lesson/{number}")]
        public async Task<IActionResult> Lesson(int id, int number)
        {
            ViewBag.Active = "courses";
            ViewBag.Number = number;

            var user = await _usersService.GetValueByСonditionAsync(e => e.UserName, User.Identity.Name);
            var article = await _arcticlesService.GetByNumber(number, id);

            if (await _arcticlesLikeService.LikeExistInArticle(article, user) != null)
                ViewBag.Liked = "liked";

            return View(await _coursesService.GetByIdAsync(id));
        }
        [Authorize]
        public async Task<IActionResult> Workshop()
        {
            ViewBag.Active = "workshop";
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Workshop(CourseModel model)
        {

            ViewBag.Active = "workshop";


            var user = await _usersService.GetValueByСonditionAsync(u => u.UserName, User.Identity.Name);
            var file = model.Uploads;

            if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
            {
                ModelState.AddModelError("Image", "Допустимі формати: png, jpg");
                return View(model);
            }

            if (file.Length > 500000 || file.Length == 0)
            {
                ModelState.AddModelError("Image", "Файл повинен бути розміром до 500КБ");
                return View(model);
            }
            var course = new Course()
            {
                Content = model.Content,
                Description = model.Description,
                CourseName = model.CourseName,
                ImagePath = "-",
                UserId = (await _usersService.GetValueByСonditionAsync(u=>u.UserName, User.Identity.Name)).Id
            };
            await _coursesService.AddAsync(course, file);
            return RedirectToAction("Index", "Home");
        }



    }
}