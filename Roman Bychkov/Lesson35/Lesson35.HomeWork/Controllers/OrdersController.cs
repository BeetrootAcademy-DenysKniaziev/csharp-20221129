namespace Lesson35.HomeWork.Controllers
{
    [Route("api/parking/[controller]")]
    [ApiController]
    public class OrdersController: ControllerBase
    {
        private ApplicationDbContext _dbContext { get; set; }
        public OrdersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<int> Get()
        {
            return Ok();
        }
    }

}