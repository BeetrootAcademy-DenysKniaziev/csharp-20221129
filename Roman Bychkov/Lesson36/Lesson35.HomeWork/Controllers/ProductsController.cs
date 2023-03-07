using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lesson35.HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [Route("GetAll")]
        [HttpGet]
        [ConsoleLogFilter]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_dbContext.Products.ToList());
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var result = _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id).Result;
            return result != null ? Ok(result) : NotFound(result);
        }
        [Route("DeleteById")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var product = _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id).Result;
            if (product is null)
                throw new NullReferenceException();
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
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
            await _dbContext.Products.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();
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
