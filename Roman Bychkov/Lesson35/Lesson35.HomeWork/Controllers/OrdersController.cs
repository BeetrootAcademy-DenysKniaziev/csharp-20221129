
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lesson35.HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ConsoleLogFilter]
    public class OrdersController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public OrdersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_dbContext.Orders.ToList());
        }
        [Route("GetById")]
        [HttpGet]
       
        public async Task<ActionResult> GetById(int id)
        {
            var result = _dbContext.Orders.FirstOrDefaultAsync(p => p.Id == id).Result;
            return result != null ? Ok(result) : NotFound(result);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            var order = _dbContext.Orders.FirstOrDefaultAsync(p => p.Id == id).Result;
            if (order is null)
                throw new NullReferenceException();
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult> PostPerson([FromBody] OrderJSON order)
        {
            Order newOrder = new Order()
            {
                PersonId = order.IdPerson,
                ProductId = order.IdProduct,
                OrderTime = order.DateCreate
            };
            await _dbContext.Orders.AddAsync(newOrder);
            await _dbContext.SaveChangesAsync();
            return Created("Created", newOrder);
        }
       
        public class OrderJSON
        {
            [JsonProperty("idProduct")]
            public int IdProduct { get; set; }
            [JsonProperty("idPerson")]
            public int IdPerson { get; set; }
            [JsonProperty("dateCreate")]
            public DateTime DateCreate { get; set; }

        }

    }

}