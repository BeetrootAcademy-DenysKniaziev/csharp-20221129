
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lesson35.HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonsServices _persons;
       
        public PersonsController(IPersonsServices persons)
        {
           _persons = persons;

        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _persons.Get());
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _persons.GetById(id);
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
            _persons.Add(newPerson);
            return Created("Created",newPerson);
        }

        [Route("DeleteById")]
        [HttpDelete]
        [ConsoleLogFilter]
        public async Task<ActionResult> Delete(int id)
        {
            _persons.Delete(_persons.GetById(id).Result);
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
