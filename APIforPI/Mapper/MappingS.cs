using APIforPI.Dto;
using APIforPI.Models;
using AutoMapper;

namespace APIforPI.Mapper
{
    public class MappingS : Profile
    {
        public MappingS()
        {
            CreateMap<Sushi, SushiDto>();
        }
    }
}
