
using APIforPI.Infrastracture.Dto;
using APIforPI.Models;
using APIforPI.Services.Contracts;
using AttributeRouting;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;

namespace APIforPI.Controllers
{

    [Route("api/SetSushi")]
    [ApiController]
    public class SetSushiController : Controller
    {
        private readonly ISushiService _sushiService;
        private readonly ISetService _setService;
        public SetSushiController(ISushiService sushiService, ISetService setService)
        {
            _sushiService= sushiService;
            _setService= setService;
           
        }
        
        [HttpGet("getAllSushis")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SushiDto>))]

        public async Task<IActionResult> GetAllSushisAsync()
        {
            
            var  result = await _sushiService.GetSushisAsync();
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return  Ok(result);
        }
        
        [HttpGet("{sushiId}")]
        [ProducesResponseType(200, Type = typeof(SushiDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSushiByIdAsync(int sushiId)
        {
            var result = await _sushiService.GetSushiByIdAsync(sushiId);
            if (result == null)
                return NotFound();
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(result);
        }
        
        [HttpGet("sushiByName/{sushiName}")]
        [ProducesResponseType(200, Type = typeof(SushiDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSushiByNameAsync(string sushiName)
        {
            var result = await _sushiService.GetSushiByNameAsync(sushiName); 
            if (result==null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }
        [HttpPost("CreateSushi")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> CreateSushiAsync(string name, int price, int weight, int quantity)
        {

            if (name == null) 
                return BadRequest(ModelState);
            var existing = await _sushiService.GetSushiByNameAsync(name);
            if (existing != null)
            {
                ModelState.AddModelError("", "Sushi already exists");
                return StatusCode(402, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           await _sushiService.CreateSushiAsync(name, price, weight, quantity);

            return Ok("Success, Sushi has been created");
        }

        [HttpGet("SetByName/{id}")]
        [ProducesResponseType(200, Type = typeof(SetsDto))]
        public async Task<IActionResult> GetSetInfo(int id)
        {
            var result = await _setService.GetSetInformationAsync(id);
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(result);
        }
        
        [HttpGet("getAllSets")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SetsDto>))]
        public async Task<IActionResult> GetAllSetsAsync()
        {
            var result = await _setService.GetAllSetsAsync();
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(result);
        }


        [HttpPost("CreateSet")]
        [ProducesResponseType(205)]
        public async Task<IActionResult> CreateSet(string name, int price, int totalAmount, IEnumerable<int> sushis)
        {
            if (name==null) 
                return BadRequest(ModelState);
            //var existing = await _setService.GetSetInformationAsync();
            //if (existing != null)
            //{
            //    ModelState.AddModelError("", "Set already exists");
            //    return StatusCode(402, ModelState);
            //}
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
           await _setService.CreateNewSetAsync(name,price,totalAmount,sushis);

            return Ok("Success, set was created");
        }
        [HttpPut("ChangeSet")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSet(string name, int totalAmount, int price, IEnumerable<int> sushis) //Переделать метод
        {
            if (name==null) 
                return BadRequest(ModelState);
            //var result = await _setService.GetSetInformationAsync(name);
            //if (result == null)
            //    return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();
            await _setService.ChangeSetAsync(name,price,totalAmount,sushis);

            return Ok("Set info changed");
        }
        [HttpDelete("DeleteSet/{setName}")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteSet(string setName) //Переделать метод
        {
            //if (await _setService.GetSetInformationAsync(setName) == null) 
            //    return NotFound();

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            await _setService.DeleteSetAsync(setName);
            return NoContent();
        }

    }
}
