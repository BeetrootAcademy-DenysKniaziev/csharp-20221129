using Microsoft.AspNetCore.Authorization;

namespace LearningSystem.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikeController : ControllerBase
    {
        private ILikeArticleService _service;
        private IUsersServices _usersService;
        private IArcticlesService _articlesService;
        public LikeController(ILikeArticleService service, IUsersServices usersService, IArcticlesService articlesService)
        {
            _service = service;
            _usersService = usersService;
            _articlesService = articlesService;
        }
        [HttpPost]
        [Route("PostLike")]
        [Authorize]
        public async Task<ActionResult> PostLike(int articleNumber, int courseId)
        {

            var user = await _usersService.GetValueByСonditionAsync(u => u.UserName, User?.Identity?.Name);
            var article = await _articlesService.GetByNumber(articleNumber, courseId);
            var articleLike = await _service.LikeExistInArticle(article, user);


            if (user == null)
                return Unauthorized();
            if (articleLike != null)
            {
                await _service.DeleteAsync(articleLike);
                return NotFound(false);
            }
            else
            {
                articleLike = new LikeArticle()
                {
                    UserId = user.Id,
                    ArticleId = article.Id

                };
                await _service.AddAsync(articleLike);
                return Ok(true);
            }

        }

    }
}
