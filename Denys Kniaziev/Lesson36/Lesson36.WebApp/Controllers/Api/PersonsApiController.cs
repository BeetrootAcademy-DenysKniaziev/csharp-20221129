using Microsoft.AspNetCore.Mvc;
using Lesson36.WebApp.Models.Api;
using Lesson36.Bll.Services;
using Lesson36.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Lesson36.WebApp.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsApiController : ControllerBase
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonsApiController> _logger;

        public PersonsApiController(IPersonService service, IMapper mapper, ILogger<PersonsApiController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get everybody
        /// </summary>
        /// <returns>All persons</returns>
        /// <response code="200">Returns all persons</response>
        [HttpGet("")]
        [Authorize]
        [ProducesResponseType(typeof(Person[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> All(CancellationToken cancellationToken) =>
            Ok(await _service.GetAll());

        /// <summary>
        /// Get persons by id
        /// </summary>
        /// <param name="id">Person's id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Person if it found</returns>
        /// <response code="200">Returns person</response>
        /// <response code="404">Returns Id</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ById([FromRoute] int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Got request {nameof(PersonsApiController)} for method {nameof(ById)}, ID={id}");

            var person = await _service.GetById(id);
            return person == null
                ? NotFound(id)
                : Ok(person);
        }

        /// <summary>
        /// Creates person
        /// </summary>
        /// <param name="request">Create person request</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Id of created person</returns>
        /// <response code="201">Returns Id of created person</response>
        [HttpPost("")]
        [ProducesResponseType(typeof(CreatePersonResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreatePersonRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var result = await _service.Add(_mapper.Map<Person>(request));

            if (!result.Success)
            {
                return ValidationProblem(new ValidationProblemDetails(result.ValidationErrors));
            }

            return StatusCode(StatusCodes.Status201Created, new CreatePersonResponse
            {
                Id = result.Data
            });
        }

        ///// <summary>
        ///// Updates person
        ///// </summary>
        ///// <param name="id">Person's id</param>
        ///// <param name="request">Update params</param>
        ///// <returns>Updated fields</returns>
        ///// <response code="200">Returns updated fields</response>
        ///// <response code="404">Returns Id</response>
        ///// <response code="500">Returns error message</response>
        //[HttpPatch("{id}")]
        //[ProducesResponseType(typeof(UpdatePersonResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(UpdatePersonInternalServerResponse), StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePersonRequest request,
        //    CancellationToken cancellationToken)
        //{
        //    var person = await _persons.People.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        //    if (person == null)
        //    {
        //        return NotFound(id);
        //    }

        //    var personType = typeof(Person);
        //    var changedProperties = new List<string>();
        //    foreach (var propertyInfo in request.GetType().GetProperties())
        //    {
        //        var fieldValue = propertyInfo.GetValue(request);

        //        if (fieldValue != null)
        //        {
        //            var destinationProperty = personType.GetProperty(propertyInfo.Name);
        //            if (destinationProperty == null)
        //            {
        //                return StatusCode(StatusCodes.Status500InternalServerError,
        //                    new UpdatePersonInternalServerResponse
        //                    {
        //                        Message = $"Property {propertyInfo.Name} not found in {personType.Name} type"
        //                    });
        //            }

        //            destinationProperty.SetValue(person, fieldValue);
        //            changedProperties.Add(destinationProperty.Name);
        //        }
        //    }

        //    if (changedProperties.Any())
        //    {
        //        await _persons.SaveChangesAsync(cancellationToken);
        //    }

        //    return Ok(new UpdatePersonResponse
        //    {
        //        UpdatedFields = changedProperties.ToArray()
        //    });
        //}

        ///// <summary>
        ///// Delete person
        ///// </summary>
        ///// <param name="id">Person's id</param>
        ///// <returns>Nothing</returns>
        ///// <response code="204"></response>
        ///// <response code="404">Returns Id</response>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        //{
        //    var person = await _persons.People.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        //    if (person == null)
        //    {
        //        return NotFound(id);
        //    }

        //    _persons.Remove(person);
        //    await _persons.SaveChangesAsync(cancellationToken);

        //    return NoContent();
        //}
    }
}
