
using APIforPI.Infrastracture.Dto;
using APIforPI.Models;
using AutoMapper;

namespace APIforPI.Mappers
{
    public class MappingS : Profile
    {
        public MappingS()
        {
            CreateMap<Sushi, SushiDto>();
            CreateMap<Sets, SetsDto>(); 
        }
    }
}
