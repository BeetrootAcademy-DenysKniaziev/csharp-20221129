

namespace LearningSystem.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikeController : ControllerBase
    {
        private ILikeArticleService _service;
        private IUsersServices _usersService;
        private IArticlesService _articlesService;
        private ILogger _logger;
        public LikeController(ILikeArticleService service, IUsersServices usersService, IArticlesService articlesService, ILogger<LikeController> logger)
        {
            _logger = logger;
            _service = service;
            _usersService = usersService;
            _articlesService = articlesService;
        }
        [HttpPost]
        [Route("PostLike")]

        public async Task<ActionResult> PostLike(int articleNumber, int courseId)
        {

            var user = await _usersService.GetByName(User.Identity.Name);
            var article = await _articlesService.GetByNumberAsync(articleNumber, courseId);
            var articleLike = await _service.LikeExistInArticle(article, user);


            if (user == null)
                return Unauthorized();
            if (article is null)
                return BadRequest();
            if (articleLike != null)
            {
                await _service.DeleteAsync(articleLike);
                _logger.LogInformation("{User} deleted like to course {CourseId} lesson {Number}. code-{Code}", User.Identity.Name, courseId, articleNumber, RepoLogEvents.UserUnLike);
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
                _logger.LogInformation("{User} added like to course {CourseId} lesson {Number}. code-{Code}", User.Identity.Name, courseId, articleNumber, RepoLogEvents.UserLike);
                return Ok(true);
            }

        }

    }
}
