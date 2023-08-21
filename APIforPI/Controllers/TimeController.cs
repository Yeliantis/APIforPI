using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Interfaces;
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
        public async Task<OnlyTimeDto> GetYourTime()
        {
            return await _timeService.GetYourTime();
        }
    }
}
