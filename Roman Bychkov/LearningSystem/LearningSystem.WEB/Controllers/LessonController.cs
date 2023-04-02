//using LearningSystem.WEB.Filters;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace LearningSystem.WEB.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize]
//    public class LessonController : ControllerBase
//    {
        
//        public LessonController(ILikeArticleService service, IUsersServices usersService, IArticlesService articlesService)
//        {
//            _service = service;
//            _usersService = usersService;
//            _articlesService = articlesService;
//        }

//        [HttpPost]
//        [NonAccessToChangeLesson()]
//        [Route("UpdateLesson")]

//        public async Task<ActionResult> UpdateLesson(LessonModel model)
//        {

//            var lesson = await _arcticlesService.GetByNumberAsync(model.Number, model.CourseId);
//            if (ModelState.IsValid)
//            {
//                lesson = _mapper.Map(model, lesson);
//                await _arcticlesService.UpdateAsync(lesson);
//            }

//            return await EditLesson(model.CourseId, model.Number);

//        }

//    }
//}
