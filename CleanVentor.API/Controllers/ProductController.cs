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

        [HttpPost]
        public ActionResult<Products> PostProduct (Products products) 
        {
            var Product = _service.CreateProduct(products);
            return Ok(products);
        }
    }
}
