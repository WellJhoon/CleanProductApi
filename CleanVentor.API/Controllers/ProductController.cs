using CleanVentor.Aplication.Interfaces;
using CleanVentor.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanVentor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Products>> Get()
        {
            var moviesFromService = _service.GetAllProducts();
            return Ok(moviesFromService);
        }

        //Get By Id:
        [HttpGet("{id}")]
        public ActionResult<Products> GetById(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, Products product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.UpdateProduct(product);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _service.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _service.DeleteProduct(id);
            return NoContent();
        }


        [HttpPost]
        public ActionResult<Products> PostProduct (Products products) 
        {
            var Product = _service.CreateProduct(products);
            return Ok(products);
        }
    }
}
