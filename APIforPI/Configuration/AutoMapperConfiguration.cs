
using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Models;
using AutoMapper;

namespace APIforPI.Configuration
    
{
    public static class AutoMapperConfiguration
    {
        public static Mapper CreateMapper()
        {
            return new Mapper(ConfigureMapper());
        }

        private static MapperConfiguration ConfigureMapper()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Sushi, SushiDto>();
                config.CreateMap<Sets, SetsDto>();
                config.CreateMap<OnlyTime,OnlyTimeDto>();
            });
        }
    }
}
