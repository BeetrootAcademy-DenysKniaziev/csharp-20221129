using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lesson35.HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsServices _products;

        public ProductsController(IProductsServices products)
        {
            _products = products;

        }
        [Route("GetAll")]
        [HttpGet]
        [ConsoleLogFilter]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _products.Get());
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _products.GetById(id);
            return result != null ? Ok(result) : NotFound(result);
        }
        [Route("DeleteById")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
             _products.Delete(await _products.GetById(id));
             return Ok("Deleted");
        }
        [HttpPost]
        [Route("AddProduct")]
        [ConsoleLogFilter]
        public async Task<ActionResult> PostPerson([FromBody] ProductJSON product)
        {
            Product newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DiscountedPrice = product.DiscountedPrice
            };
            _products.Add(newProduct);
            return Created("Created", newProduct);
        }
        public class ProductJSON
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("price")]
            public decimal Price { get; set; }
            [JsonProperty("discountedPrice")]
            public decimal DiscountedPrice { get; set; }

        }

    }

}
