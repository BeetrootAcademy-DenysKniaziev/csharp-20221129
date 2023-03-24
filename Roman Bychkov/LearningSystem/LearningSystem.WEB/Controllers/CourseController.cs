namespace LearningSystem.WEB.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoursesService _service;
        private IUsersServices _usersService;
        private ILikeArticleService _arcticlesLikeService;
        private IArcticlesService _arcticlesService;
        public CourseController(ILogger<HomeController> logger, ICoursesService service, IUsersServices usersServices,
            ILikeArticleService articleLikeService, IArcticlesService arcticlesService)
        {
            _logger = logger;
            _service = service;
            _usersService = usersServices;
            _arcticlesLikeService = articleLikeService;
            _arcticlesService = arcticlesService;
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

            var user = await _usersService.GetValueByСonditionAsync(e => e.UserName, User.Identity.Name);
            var article = await _arcticlesService.GetByNumber(number, id);

            if (await _arcticlesLikeService.LikeExistInArticle(article, user) != null)
                ViewBag.Liked = "liked";

            return View(await _service.GetByIdAsync(id));
        }

    }
}