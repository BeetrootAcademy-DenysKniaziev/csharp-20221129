using Microsoft.AspNetCore.Authorization;

namespace LearningSystem.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
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
        public async Task<ActionResult> PostLike(int articleNumber, int courseId)
        {
            string userLogin = Request?.Cookies["user_login"], password = Request?.Cookies["user_pass"];
            var user = await _usersService.GetUserByLoginPassword(userLogin, password);
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
