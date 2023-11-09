using APIforPI.Actions.Contracts;
using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Services.Contracts;
using AttributeRouting.Helpers;
using AutoMapper;

namespace APIforPI.Services
{
    public class WorldApiService : IWorldApiService
    {
        private readonly ITimeApi _timeApi;
        public WorldApiService(ITimeApi timeApi)
        {
            _timeApi = timeApi;
        }
        public async Task<OnlyTimeDto> GetYourTime()
        {
            var time = await _timeApi.GetYourTime();
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<OnlyTime, OnlyTimeDto>());
            return new Mapper(configuration).Map<OnlyTimeDto>(time);
            
            
            
        }
    }
}
