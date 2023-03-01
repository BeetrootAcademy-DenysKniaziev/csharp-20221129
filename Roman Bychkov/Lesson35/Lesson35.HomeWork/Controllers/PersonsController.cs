
namespace Lesson35.HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private HttpContext _httpContext;
        public PersonsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [Route("GetAll")]
        [HttpGet]
        public ActionResult<List<Person>> GetAll()
        {
            return Ok(_dbContext.Persons.ToList());
        }
        [Route("GetById")]
        [HttpGet]
        public ActionResult<Person> GetById(int id)
        {
            var result = _dbContext.Persons.FirstOrDefault(p => p.Id == id);
            return result != null ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Route("AddPerson")]
        public ActionResult<Person> PostPerson([FromBody] Person person)
        {

            Response.StatusCode = 201;
            return Ok(person);
            //_dbContext.Persons.Add(person);
            //return person;
        }

    }

}
