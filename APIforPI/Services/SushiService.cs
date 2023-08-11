
using APIforPI.Interfaces;
using APIforPI.Models;
using APIforPI.Infrastracture.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using APIforPI.Infrastracture.Dto;

namespace APIforPI.Services
{
    public class SushiService : ISushiService
    {

        private readonly IDbSushiService _databaseService;
        
        public SushiService(IDbSushiService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
           
        }
        public async Task<IEnumerable<SushiDto>> GetSushisAsync()
        {
            var list = await _databaseService.GetAllSushisAsync();
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Sushi, SushiDto>());
            return new Mapper(configuration).Map<IEnumerable<SushiDto>>(list);
        }

        public async Task<SushiDto> GetSushiByNameAsync(string name)
        {
            var result = await _databaseService.GetSushiAsync(name);
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Sushi, SushiDto>());
            return new Mapper(configuration).Map<SushiDto>(result);
        }

        public async Task<SushiDto> GetSushiByIdAsync(int id)
        {
            var result = await _databaseService.GetSushiWithIdAsync(id);
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Sushi, SushiDto>());
            return new Mapper(configuration).Map<SushiDto>(result);

        }
        public async Task<Sushi> CreateSushiAsync(string name, int price, int weight, int quantity)
        {
           var result = await _databaseService.CreateSushiAsync(name,price,weight,quantity);
            return result;
        }
    }
}
