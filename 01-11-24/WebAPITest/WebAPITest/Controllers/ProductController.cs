using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITest.Data;
using WebAPITest.Model;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;
        public ProductController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prod = await _dbContext.Products.ToListAsync();
            return Ok(prod);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var prod = _dbContext.Products.FirstOrDefault(s => s.Id == id);
            return Ok(prod);
        }

        [HttpPost]
        public IActionResult AddProduct(Product pro)
        {
            _dbContext.Products.Add(pro);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = pro.Id }, pro);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, Product pro)
        {
            var prod= _dbContext.Products.FirstOrDefault(p => p.Id == id);
            prod.Name = pro.Name;
                prod.Price = pro.Price;
                prod.Colour = pro.Colour;
                prod.Weight = pro.Weight;
            _dbContext.SaveChanges();
            return Ok(prod);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var prod = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(prod);
            _dbContext.SaveChanges();
            return Ok(prod);
        }


    }
}
