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

        [NonExistentCourseFilter(typeof(ICoursesService))]
        [Route("[controller]/{id}/Lessons")]
        [HttpGet]
        public async Task<IActionResult> Lesson(int id)
        {
            ViewBag.Active = "courses";
            var model = await _coursesService.GetByIdAsync(id);
            return View(model);
        }

        [NotExistentArticleFilter(typeof(IArcticlesService))]
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


            var user = await _usersService.GetValueByСonditionAsync(u => u.UserName, User?.Identity?.Name);
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
                var course = new Course()
                {
                    Content = model.Content,
                    Description = model.Description,
                    CourseName = model.CourseName,
                    ImagePath = "-",
                    UserId = (await _usersService.GetValueByСonditionAsync(u => u.UserName, User?.Identity?.Name)).Id
                };

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
            //var user = await _usersService.GetValueByСonditionAsync(u => u.UserName, User?.Identity?.Name);
            //if (!user.Courses.Exists(c => c.Id == id))
            //    return RedirectToAction("Oops", "Home", new { message = "Course does not exist" });
            var course = await _coursesService.GetByIdAsync(id);
            var model = new CourseModel()
            {
                CourseName = course.CourseName,
                Content = course.Content,
                Description = course.Description,
                Id = id
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [NonAccessToChangeCourse(typeof(ICoursesService))]
        public async Task<IActionResult> Edit(CourseModel model)
        {
            //var user = await _usersService.GetValueByСonditionAsync(u => u.UserName, User?.Identity?.Name);
            //if (!user.Courses.Exists(c => c.Id == model.Id))
            //    return RedirectToAction("Oops", "Home", new { message = "Course does not exist" });


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

            course.Content = model.Content;
            course.Description = model.Description;
            course.CourseName = model.CourseName;
            course.ImagePath = path ?? course.ImagePath;

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
            //if (course is null || course.User.UserName != User?.Identity?.Name || !course.Articles.Exists(a => a.Number == number))
            //    return RedirectToAction("Oops", "Home", new { message = "Lesson does not exist" });

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
            //if (model == null)
            //    return RedirectToAction("Oops", "Home", new { message = "Course does not exist" });
            ViewBag.Active = "courses";
            return View(model);
        }
        [HttpPost]
        [Authorize]
        [NonAccessToChangeCourse(typeof(ICoursesService))]
        public async Task<IActionResult> EditLesson(LessonModel model)
        {

            var course = await _coursesService.GetByIdAsync(model.Id);
            if (course.User.UserName != User?.Identity?.Name || !course.Articles.Exists(a => a.Number == model.Number))
                return RedirectToAction("Oops", "Home", new { message = "Lesson does not exist" });
            var lesson = await _arcticlesService.GetByNumberAsync(model.Number, model.Id);
            if (ModelState.IsValid)
            {
                lesson.Content = model.Content;
                lesson.ArcticleName = model.Name;
                await _arcticlesService.UpdateAsync(lesson);
            }

            return await EditLesson(model.Id, model.Number);

        }
        [HttpPost]
        [Authorize]
        [NonAccessToChangeCourse(typeof(ICoursesService))]
        public async Task<IActionResult> AddLesson(int id)
        {
            //var course = await _coursesService.GetByIdAsync(id);
            //if (course.User.UserName != User?.Identity?.Name)
            //    return RedirectToAction("Oops", "Home", new { message = "Course does not exist" });

            var article = new Article()
            {
                ArcticleName = "Новий Урок",
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
            //var user = await _usersService.GetValueByСonditionAsync(u => u.UserName, User?.Identity?.Name);
            //if (!user.Courses.Exists(c => c.Id == id))
            //    return RedirectToAction("Oops", "Home", new { message = "Course does not exist" });
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
            //if (course.User.UserName != User?.Identity?.Name || !course.Articles.Exists(a => a.Number == number))
            //    return RedirectToAction("Oops", "Home", new { message = "Lesson does not exist" });

            await _arcticlesService.DeleteAsync(course.Articles.SingleOrDefault(a => a.Number == number));
            return RedirectToAction("EditLesson", "Course", new { id = id });
        }

    }
}