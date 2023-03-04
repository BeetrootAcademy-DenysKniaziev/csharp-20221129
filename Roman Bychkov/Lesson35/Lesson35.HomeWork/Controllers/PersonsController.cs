
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lesson35.HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
       
        public PersonsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_dbContext.Persons.ToList());
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var result = _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == id).Result;
            return result != null ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [Route("AddPerson")]
        [ConsoleLogFilter]
        public async Task<ActionResult> PostPerson([FromBody] PersonJSON person)
        {
            Person newPerson = new Person()
            {
                Age = person.Age,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                Address = person.Address
            };
            await _dbContext.Persons.AddAsync(newPerson);
            await _dbContext.SaveChangesAsync();
            return Created("Created",newPerson);
        }

        [Route("DeleteById")]
        [HttpDelete]
        [ConsoleLogFilter]
        public async Task<ActionResult> Delete(int id)
        {
            var person = _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == id).Result;
            if (person is null)
                throw new NullReferenceException();
            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();
            return Ok("Deleted");
        }
        public class PersonJSON
        {
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
            [JsonProperty("lastName")]
            public string LastName { get; set; }
            [JsonProperty("age")]
            public int Age { get; set; }
            [JsonProperty("gender")]
            public string Gender { get; set; }
            [JsonProperty("address")]
            public string Address { get; set; }
        }

    }

}
