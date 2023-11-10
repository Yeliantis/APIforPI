using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace APIforPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
        {
            var result = await _productService.GetProductsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (result==null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        public async Task<ActionResult<ProductDto>> GetProductAsync(int id)
        {
            var result = await _productService.GetItemAsync(id);
     
            if (result==null)
                return NotFound();
            if (result.Name==null)
            {
                ModelState.AddModelError("Name", "Name shouldn't be null");
                return BadRequest(ModelState);
            }
            return Ok(result);
        }
    }
}
