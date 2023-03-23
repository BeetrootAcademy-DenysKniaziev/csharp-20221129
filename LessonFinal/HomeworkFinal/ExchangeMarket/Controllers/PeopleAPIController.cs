using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExchangeMarket.DAL;
//using ExchangeMarket.Models;
using ExchangeMarket.Filters;
using Contracts;
using BAL.Services;
using Newtonsoft.Json;
using Serilog;
using BAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
//using System.Web.Http;
//using Contracts;

namespace ExchangeMarket.Controllers
{
    [SecondLoggingFilterAttribute]
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleAPIController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleAPIController(IPersonService personService)
        {
            //_personService = context;
            _personService = personService;
        }


        // GET: api/PeopleAPI
        [HttpGet]

        //[Authorize]
        //[System.Web.Http.Authorize]
        //[Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {

            var persons = await _personService.GetAllPeopleAsync();

            //var pr = Problem("Some one obsorve list of our members");
            //var prData = new
            //{
            //    membersCount = persons.Count(),
            //    message = "Some one obsorved list of our members"
            //};
            var json = JsonConvert.SerializeObject(new  {  membersCount = persons.Count(), message = "Some one obsorved list of our members"  });
            Log.Information(json);
            return (ActionResult<IEnumerable<Person>>)Ok(persons);
        }

        // GET: api/PeopleAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/PeopleAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            try
            {
                await _personService.UpdatePersonAsync(person);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id == null || _personService.GetPersonByIdAsync == null)
                {
                    var pr = Problem("This member is not found");

                    var prData = new
                    {
                        value = pr.Value,
                        status = pr.StatusCode
                    };
                    var json = JsonConvert.SerializeObject(prData);
                    Log.Information(json);
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            {
                var pr = Problem("No content for update");

                var prData = new
                {
                    value = pr.Value,
                    status = pr.StatusCode
                };
                var json = JsonConvert.SerializeObject(prData);
                Log.Information(json);
            }
            return NoContent();
        }

        // POST: api/PeopleAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            try
            {
                await _personService.AddPersonAsync(person);
            }
            catch(Exception Ex)
            {
                var pr = Problem("Can`t add member... and you know why");

                var prData = new
                {
                    value = pr.Value,
                    status = pr.StatusCode,
                    ex = Ex.Message,
                    source = Ex.Source

                };
                var json = JsonConvert.SerializeObject(prData);
                Log.Information(json);
            }

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/PeopleAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await _personService.DeletePersonAsync(person);

            return NoContent();
        }
    }
}
