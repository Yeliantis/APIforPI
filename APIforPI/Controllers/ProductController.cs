using APIforPI.Infrastracture.Models;
using APIforPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIforPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getAllProduct")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(result);
        }
    }
}
