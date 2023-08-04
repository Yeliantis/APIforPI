using APIforPI.Dto;
using APIforPI.Interfaces;
using APIforPI.Models;
using AttributeRouting;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;

namespace APIforPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SetSushiController : Controller
    {
        private ISushiService _sushiService;
        private ISetService _setService;
        public SetSushiController(ISushiService sushiService, ISetService setService)
        {
            _sushiService= sushiService;
            _setService= setService;
           
        }

        [HttpGet("getAllSushis")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SushiDto>))]

        public IActionResult GetSushis()
        {
            var result = _sushiService.GetSushis();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpGet("{sushiId}")]
        [ProducesResponseType(200, Type = typeof(Sushi))]
        [ProducesResponseType(400)]
        public IActionResult GetSushi(int sushiId)
        {
            var result = _sushiService.GetSushi(sushiId);
            if (result == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(result);
        }
        // В HttpGet были две точки входа с одинаковыми маршрутами, добавил отличие
        [HttpGet("sushiByName/{sushiName}")]
        [ProducesResponseType(200, Type = typeof(Sushi))]
        [ProducesResponseType(400)]
        public IActionResult GetSushiByName(string sushiName)
        {
            var result = _sushiService.GetSushiByName(sushiName); 
            if (result==null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(result);
        }
        [HttpPost("CreateSushi")]
        [ProducesResponseType(204)]
        public IActionResult CreateSushi(string name, int price, int weight, int quantity)
        {

            if (name == null) return BadRequest(ModelState);
            var existing = _sushiService.GetSushiByName(name);
            if (existing != null)
            {
                ModelState.AddModelError("", "Sushi already exists");
                return StatusCode(402, ModelState);
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _sushiService.CreateSushi(name, price, weight, quantity);
            return Ok("Success, created");
        }

        [HttpGet("SetByName/{name}")]
        [ProducesResponseType(200, Type = typeof(Sets))]
        public IActionResult GetSetInfo(string name)
        {
            var result = _setService.GetSetInformation(name);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(result);
        }
        
        [HttpGet("getAllSets")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Sets>))]
        public IActionResult GetAllSets()
        {
            var result = _setService.GetAllSets();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(result);
        }


        [HttpPost("CreateSet")]
        [ProducesResponseType(205)]
        public IActionResult CreateSet(string name, int price, int totalAmount, IEnumerable<int> sushis)
        {
            if (name==null) return BadRequest(ModelState);
            var existing = _setService.GetSetInformation(name);
            if (existing != null)
            {
                ModelState.AddModelError("", "Set already exists");
                return StatusCode(402, ModelState);
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _setService.CreateNewSet(name,price,totalAmount,sushis);
            return Ok("Success, set was created");
        }
        [HttpPut("ChangeSet")]
        [ProducesResponseType(400)]
        public IActionResult UpdateSet(string name, int totalAmount, int price, IEnumerable<int> sushis)
        {
            if (name==null) return BadRequest(ModelState);
            var result = _setService.GetSetInformation(name);
            if (result == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();
            _setService.ChangeSet(name,price,totalAmount,sushis);
            return Ok("Set info changed");
        }
        [HttpDelete("DeleteSet/{setName}")]
        [ProducesResponseType(400)]
        public IActionResult DeleteSet(string setName)
        {
            if (_setService.GetSetInformation(setName) == null) 
                return NotFound();

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

             _setService.DeleteSet(setName);
            return NoContent();
        }

    }
}
