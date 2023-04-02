using AutoMapper;
using LearningSystem.WEB.Filters;
using LearningSystem.WEB.ValidationModels;
using Microsoft.AspNetCore.Authorization;

namespace LearningSystem.WEB.Controllers
{

    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private ICoursesService _coursesService;
        private IUsersServices _usersService;
        private ILikeArticleService _arcticlesLikeService;
        private IArticlesService _arcticlesService;
        private IMapper _mapper;
        public CourseController(ILogger<CourseController> logger, ICoursesService service, IUsersServices usersServices,
            ILikeArticleService articleLikeService, IArticlesService arcticlesService, IMapper mapper)
        {
            _logger = logger;
            _coursesService = service;
            _usersService = usersServices;
            _arcticlesLikeService = articleLikeService;
            _arcticlesService = arcticlesService;
            _mapper = mapper;
        }

        [NonExistentCourseFilter()]
        [Route("[controller]/{id}/Lessons")]
        [HttpGet]
        public async Task<IActionResult> Lesson(int id)
        {
            ViewBag.Active = "courses";
            var model = await _coursesService.GetByIdUserArticleIncludesAsync(id);
            return View(model);
        }

        [NotExistentArticleFilter()]
        [Route("[controller]/{id}/Lesson/{number}")]
        [HttpGet]
        public async Task<IActionResult> Lesson(int id, int number)
        {
            ViewBag.Active = "courses";
            ViewBag.Number = number;

            var user = await _usersService.GetValueByСonditionAsync(e => e.UserName, User?.Identity?.Name);
            var article = await _arcticlesService.GetByNumberAsync(number, id);

            if (await _arcticlesLikeService.LikeExistInArticle(article, user) != null)
                ViewBag.Liked = "liked";


            return View(await _coursesService.GetByIdAllIncludesAsync(id));
        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> Workshop()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Workshop(CourseModel model)
        {

            ViewBag.Active = "workshop";
            var file = model.Uploads;
            if (ModelState.IsValid)
            {
                var course = _mapper.Map<Course>(model);
                course.UserId = (await _usersService.GetValueByСonditionAsync(u => u.UserName, User?.Identity?.Name)).Id;

                await _coursesService.AddAsync(course, file);
                return RedirectToAction("Index", "Home");
            }
            else
                return View(model);

        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> MyCourses()
        {

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            return View((await _coursesService.GetAllWithUserAsync()).Where(x => x.User.UserName == User?.Identity?.Name).ToList());
        }

        [Authorize]
        [HttpGet]
        [NonAccessToChangeCourse()]
        public async Task<IActionResult> Edit(int id)
        {
            Course course = await _coursesService.GetByIdAsync(id);
            var model = _mapper.Map<CourseModel>(course);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [NonAccessToChangeCourse()]
        public async Task<IActionResult> Edit(CourseModel model)
        {
            if (ModelState.IsValid)
            {

                var path = await _coursesService.AddImage(model.Id, model.Uploads);
                var course = await _coursesService.GetByIdAsync(model.Id);

                _mapper.Map<CourseModel, Course>(model, course);
                course.ImagePath = path ?? course.ImagePath;

                await _coursesService.UpdateAsync(course);

                await _coursesService.UpdateAsync(course);
                return RedirectToAction("Index", "Home");
            }
            return View(model);

        }
        [Route("[controller]/{id}/EditLesson/{number}")]
        [HttpGet]
        [Authorize]
        [NonAccessToChangeLesson()]
        public async Task<IActionResult> EditLesson(int id, int number)
        {
            var course = await _coursesService.GetByIdUserArticleIncludesAsync(id);
            ViewBag.Number = number;
            return View(course);
        }
        [Route("[controller]/{id}/EditLesson")]
        [HttpGet]
        [Authorize]
        [NonAccessToChangeCourse()]
        public async Task<IActionResult> EditLesson(int id)
        {
            var model = await _coursesService.GetByIdUserArticleIncludesAsync(id);
            ViewBag.Active = "courses";
            return View(model);
        }
        [HttpPost]
        [Authorize]
        [NonAccessToChangeLesson()]
      
        public async Task<IActionResult> EditLesson(LessonModel model)
        {

            var lesson = await _arcticlesService.GetByNumberAsync(model.Number, model.CourseId);
            if (ModelState.IsValid)
            {
                lesson = _mapper.Map(model, lesson);
                await _arcticlesService.UpdateAsync(lesson);
            }

            return await EditLesson(model.CourseId, model.Number);

        }
        [HttpPost]
        [Authorize]
        [NonAccessToChangeCourse()]
        public async Task<IActionResult> AddLesson(int id)
        {
            var article = new Article()
            {
                ArticleName = "Новий Урок",
                Content = "Тут нічого не має",
                CourseId = id
            };
            await _arcticlesService.AddAsync(article);
            return RedirectToAction("EditLesson", "Course", new { id = id, number = article.Number });
        }

        [Authorize]
        [NonAccessToChangeCourse()]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _coursesService.DeleteAsync(await _coursesService.GetByIdAsync(id));
            return RedirectToAction("MyCourses", "Course");
        }
        [Authorize]
        [HttpPost]
        [NonAccessToChangeLesson()]
        [Route("{id}/DeleteLesson/{number}")]
        public async Task<IActionResult> DeleteLesson(int id, int number)
        {
            var course = await _coursesService.GetByIdUserArticleIncludesAsync(id);
            await _arcticlesService.DeleteAsync(course.Articles.SingleOrDefault(a => a.Number == number));
            return RedirectToAction("EditLesson", "Course", new { id = id });
        }

    }
}