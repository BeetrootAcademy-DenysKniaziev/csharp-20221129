using LearningSystem.WEB.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessonController : ControllerBase
    {
        private IMapper _mapper;
        private IArticlesService _articlesService;
        public LessonController(IMapper mapper, IArticlesService articlesService)
        {
          
            _mapper = mapper;
            _articlesService = articlesService;
        }

        [HttpPost]
        [NonAccessToChangeLesson()]
        [Route("UpdateLesson")]

        public async Task<ActionResult> UpdateLesson(LessonModel model)
        {

            var lesson = await _articlesService.GetByNumberAsync(model.Number, model.CourseId);
            if (ModelState.IsValid)
            {
                lesson = _mapper.Map(model, lesson);
                await _articlesService.UpdateAsync(lesson);
            }

            return Ok();

        }

    }
}
