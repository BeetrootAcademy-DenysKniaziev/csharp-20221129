using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;


namespace LearningSystem.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   
    public class CommentController : ControllerBase
    {
        private ICommentsService _service;
        private IUsersServices _usersService;
        private IArticlesService _articlesService;
        public CommentController(ICommentsService service, IUsersServices usersService, IArticlesService articlesService)
        {
            _service = service;
            _usersService = usersService;
            _articlesService = articlesService;
        }
        [HttpPost]
        [Route("PostComment")]
        public async Task<ActionResult<Comment>> PostComment(int articleNumber, int courseId, [FromForm] string comment)
        {

            var user = await _usersService.GetValueByСonditionAsync(u => u.UserName, User.Identity.Name);

            if (user == null)
                return Unauthorized();

            if (comment.Length > 250 || comment.Length == 0)
                return BadRequest();


            var article = await _articlesService.GetByNumberAsync(articleNumber, courseId);
            var newComment = new Comment
            {
                UserId = user.Id,
                ArticleId = article.Id,
                Content = comment
            };
            await _service.AddAsync(newComment);
            var newOb = new
            {
                userLogin = User.Identity.Name,
                comment = comment,
                createDays = newComment.Created.ToShortDateString(),
                createTime = newComment.Created.ToShortTimeString(),
                image = user.Image
            };
            string jsonString = JsonConvert.SerializeObject(newOb, Formatting.Indented);
            return Content(jsonString);
        }

    }
}


