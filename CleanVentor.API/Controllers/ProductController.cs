using CleanVentor.Aplication.Interfaces;
using CleanVentor.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Dynamic;


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


        [HttpPost]
        public ActionResult<Products> PostProduct(Products products)
        {
            var Product = _service.CreateProduct(products); // Creates a new product by calling the service.
            return Ok(products); // Returns the newly created product.
        }

        //Get all Users 
        [HttpGet]
        public ActionResult<List<Products>> Get()
        {
            var productFromService = _service.GetAllProducts();
            return Ok(productFromService);
        }

        //Get User for Id
        [HttpGet("{id}")]
        public ActionResult<Products> GetById(int id)
        {
            var product = _service.GetProductById(id); //Get Product from service
            if (product == null)
            {
                return NotFound();//If Product is not Found make 404
            }
            return Ok(product); //return product
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, Products product)
        {
            if (id != product.Id)
            {
                return BadRequest(); //Return 404 if the product Id is does mach with Id
            }

            try
            {
                _service.UpdateProduct(product); //Tries to update the product by calling the service.
            }
            catch (Exception)
            {
                return NotFound(); //Returns a 404 error if the product to update cannot be found.
            }

            return NoContent(); //Returns a 204 status to indicate the update was successful.
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _service.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound(); // Returns a 404 error if the product to delete cannot be found.
            }

            _service.DeleteProduct(id); // Deletes the product by calling the service.
            return NoContent();// Returns a 204 status
        }


     
    }
}
