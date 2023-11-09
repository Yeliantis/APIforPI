using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;

namespace APIforPI.Controllers
{
    [Route("api/Time")]
    [ApiController]
    public class TimeController : Controller
    {
        private readonly IWorldApiService _timeService;
            public TimeController(IWorldApiService timeService)
        {
            _timeService = timeService;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(OnlyTimeDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OnlyTimeDto>> GetYourTime()
        {
            var result = await _timeService.GetYourTime();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(result);
        }
    }
}
