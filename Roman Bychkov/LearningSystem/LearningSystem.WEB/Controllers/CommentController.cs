using System.Text.Json;
using Newtonsoft.Json;

namespace LearningSystem.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentsService _service;
        private IUsersServices _usersService;
        private IArcticlesService _articlesService;
        public CommentController(ICommentsService service, IUsersServices usersService, IArcticlesService articlesService)
        {
            _service = service;
            _usersService = usersService;
            _articlesService = articlesService;
        }
        [HttpPost]
        [Route("PostComment")]
        public async Task<ActionResult<Comment>> PostComment(int articleNumber, int courseId, [FromForm] string comment)
        {
            if (comment.Length > 250)
                return BadRequest();
            //Для прикладу, беремо тут дані з куків
            string userLogin = "qwe1", password = "Qq1";
            if (true)
            {
                var user = await _usersService.GetUserByLoginPassword(userLogin, password);
                var article = await _articlesService.GetByNumber(articleNumber, courseId);
                var newComment = new Comment
                {
                    UserId = user.Id,
                    ArticleId = article.Id,
                    Content = comment
                };
                await _service.AddAsync(newComment);
                var newOb = new
                {
                    userLogin = userLogin,
                    comment = comment,
                    created = newComment.Created.ToShortDateString()
                };
                string jsonString = JsonConvert.SerializeObject(newOb, Formatting.Indented);
                return Content(jsonString);
            }
            else
                return Unauthorized();
        }



    }

}
