using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results.DataResults;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        //Inversion of Control Container -- IOC Container
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.IsSuccess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetByİd(int id)
        {
            var result = _productService.GetById(id);
            if (result.IsSuccess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.IsSuccess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //        { BODY SCRIPT
        //    "CategoryId" : 1,
        //    "ProductName" : "Laptop",
        //    "UnitsInStock" : 550,
        //    "UnitPrice" : 3400
        //}
    }
}
