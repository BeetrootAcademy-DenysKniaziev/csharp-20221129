using AutoMapper;
using LearningSystem.WEB.Filters;
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
        private IArticlesService _arcticlesService;
        private IMapper _mapper;
        public CourseController(ILogger<HomeController> logger, ICoursesService service, IUsersServices usersServices,
            ILikeArticleService articleLikeService, IArticlesService arcticlesService, IMapper mapper)
        {
            _logger = logger;
            _coursesService = service;
            _usersService = usersServices;
            _arcticlesLikeService = articleLikeService;
            _arcticlesService = arcticlesService;
            _mapper = mapper;
        }

        [NonExistentCourseFilter(typeof(ICoursesService))]
        [Route("[controller]/{id}/Lessons")]
        [HttpGet]
        public async Task<IActionResult> Lesson(int id)
        {
            ViewBag.Active = "courses";
            var model = await _coursesService.GetByIdAsync(id);
            return View(model);
        }

        [NotExistentArticleFilter(typeof(IArticlesService))]
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


            return View(await _coursesService.GetByIdAsync(id));
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

            if (file is null || file.Length > 500000)
            {
                ModelState.AddModelError("Image", "Файл повинен бути розміром до 500КБ");
                return View(model);
            }
            if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
            {
                ModelState.AddModelError("Image", "Допустимі формати: png, jpg");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var course = _mapper.Map<Course>(model);
                course.UserId = (await _usersService.GetValueByСonditionAsync(u => u.UserName, User?.Identity?.Name)).Id;

               await _coursesService.AddAsync(course, file);
            }
            return RedirectToAction("Index", "Home");
        }


        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> MyCourses()
        {

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            return View((await _coursesService.GetAsync()).Where(x => x.User.UserName == User?.Identity?.Name).ToList());
        }

        [Authorize]
        [HttpGet]
        [NonAccessToChangeCourse(typeof(ICoursesService))]
        public async Task<IActionResult> Edit(int id)
        {
            Course course = await _coursesService.GetByIdAsync(id);
            var model = _mapper.Map<CourseModel>(course);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [NonAccessToChangeCourse(typeof(ICoursesService))]
        public async Task<IActionResult> Edit(CourseModel model)
        {
            var file = model.Uploads;

            string path;

            if (file is null)
            {
                path = null;
            }
            else if (file.Length > 500000)
            {
                ModelState.AddModelError("Image", "Файл повинен бути розміром до 500КБ");
                return View(model);
            }
            else if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
            {
                ModelState.AddModelError("Image", "Допустимі формати: png, jpg");
                return View(model);
            }
            else
            {
                path = await _coursesService.AddImage(model.Id, model.Uploads);
            }
            // Я прибрав перевірку ModelState, так як якщо користувач не завантажить файл, то буде використаний файл, який був ДО
            // Якщо не ставити атрибут [Required], то все одно потребує завантажити файл (?)
            var course = await _coursesService.GetByIdAsync(model.Id);

            _mapper.Map<CourseModel, Course>(model, course);
            course.ImagePath = path ?? course.ImagePath;

            await _coursesService.UpdateAsync(course);

            await _coursesService.UpdateAsync(course);
            return RedirectToAction("Index", "Home");

            //return View(model);

        }
        [Route("[controller]/{id}/EditLesson/{number}")]
        [HttpGet]
        [Authorize]
        [NonAccessToChangeLesson(typeof(ICoursesService))]
        public async Task<IActionResult> EditLesson(int id, int number)
        {
            var course = await _coursesService.GetByIdAsync(id);
            ViewBag.Number = number;
            return View(course);
        }
        [Route("[controller]/{id}/EditLesson")]
        [HttpGet]
        [Authorize]
        [NonAccessToChangeCourse(typeof(ICoursesService))]
        public async Task<IActionResult> EditLesson(int id)
        {
            var model = await _coursesService.GetByIdAsync(id);
            ViewBag.Active = "courses";
            return View(model);
        }
        [HttpPost]
        [Authorize]
        [NonAccessToChangeLesson(typeof(ICoursesService))]
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
        [NonAccessToChangeCourse(typeof(ICoursesService))]
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
        [NonAccessToChangeCourse(typeof(ICoursesService))]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _coursesService.DeleteAsync(await _coursesService.GetByIdAsync(id));
            return RedirectToAction("MyCourses", "Course");
        }
        [Authorize]
        [HttpPost]
        [NonAccessToChangeLesson(typeof(ICoursesService))]
        [Route("{id}/DeleteLesson/{number}")]
        public async Task<IActionResult> DeleteLesson(int id, int number)
        {
            var course = await _coursesService.GetByIdAsync(id);
            await _arcticlesService.DeleteAsync(course.Articles.SingleOrDefault(a => a.Number == number));
            return RedirectToAction("EditLesson", "Course", new { id = id });
        }

    }
}