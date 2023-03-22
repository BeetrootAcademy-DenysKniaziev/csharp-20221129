﻿namespace LearningSystem.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            string userLogin = "qwe1", password = "Qq1";
            if (true);
            //Для прикладу, беремо тут дані з куків
            else
                return Unauthorized();

            var user = await _usersService.GetUserByLoginPassword(userLogin, password);
            var article = await _articlesService.GetByNumber(articleNumber, courseId);
            var articleLike = await _service.LikeExistInArticle(article, user);

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
