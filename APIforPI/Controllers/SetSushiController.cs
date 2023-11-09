
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
                return NotFound("Sushi doesn't exist");
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(result);
        }
        
        [HttpGet("sushiByName/{sushiName}")]
        [ProducesResponseType(200, Type = typeof(SushiDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSushiByNameAsync(string sushiName)
        {
            var result = await _sushiService.GetSushiByNameAsync(sushiName); 
            if (result==null)
                return NotFound("Sushi doesn't exist");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }
        [HttpPost("CreateSushi")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSushiAsync([FromBody] SushiDto sushi)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _sushiService.CreateSushiAsync(sushi);
            if (result==null)
            {
                return BadRequest("Something definitely went wrong");
            }

            return Ok("Success, Sushi has been created");
        
        }

        [HttpGet("SetByName/{id}")]
        [ProducesResponseType(200, Type = typeof(SetsDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSetInfo(int id)
        {
            var result = await _setService.GetSetInformationAsync(id);
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            if (result==null)
                return NotFound("Set doesn't exist");

            return Ok(result);
        }
        
        [HttpGet("getAllSets")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SetsDto>))]
        public async Task<IActionResult> GetAllSetsAsync()
        {
            var result = await _setService.GetAllSetsAsync();
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            if (result == null)
                return NotFound("Failed to retrive info");
            return Ok(result);
        }


        [HttpPost("CreateSet")]
        [ProducesResponseType(205)]
        public async Task<IActionResult> CreateSet(string name, int price, int totalAmount, IEnumerable<int> sushis)
        {

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
           var result = await _setService.CreateNewSetAsync(name, price, totalAmount, sushis);
            if (result==null)
            {
                return BadRequest("Failed to create");
            }

            return Ok("Success, set has been created");
        }
        
        [HttpDelete("DeleteSet/{setId}")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteSet(int setId)
        {
            if (await _setService.GetSetInformationAsync(setId) == null)
                return NotFound();

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            await _setService.DeleteSetAsync(setId);
            return Ok("Set has been deleted");
        }

    }
}
