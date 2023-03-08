
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lesson35.HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ConsoleLogFilter]
    public class OrdersController : ControllerBase
    {
        private IOrdersServices _orders;

        public OrdersController(IOrdersServices orders)
        {
            _orders = orders;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _orders.Get());
        }
        [Route("GetById")]
        [HttpGet]
       
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _orders.GetById(id);
            return result != null ? Ok(result) : NotFound(result);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            _orders.Delete(await _orders.GetById(id));
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
            _orders.Add(newOrder);
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