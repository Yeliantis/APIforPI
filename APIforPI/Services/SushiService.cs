
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

        private readonly IDbSushiService _dbSushiService;
        
        public SushiService(IDbSushiService databaseService)
        {
            _dbSushiService = databaseService;
           
        }
        public async Task<IEnumerable<SushiDto>> GetSushisAsync()
        {
            var list = await _dbSushiService.GetAllSushisAsync();
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Sushi, SushiDto>());
            return new Mapper(configuration).Map<IEnumerable<SushiDto>>(list);
        }

        public async Task<SushiDto> GetSushiByNameAsync(string name)
        {
            var result = await _dbSushiService.GetSushiAsync(name);
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Sushi, SushiDto>());
            return new Mapper(configuration).Map<SushiDto>(result);
        }

        public async Task<SushiDto> GetSushiByIdAsync(int id)
        {
            var result = await _dbSushiService.GetSushiWithIdAsync(id);
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Sushi, SushiDto>());
            return new Mapper(configuration).Map<SushiDto>(result);

        }
        public async Task<Sushi> CreateSushiAsync(string name, int price, int weight, int quantity)
        {
           var result = await _dbSushiService.CreateSushiAsync(name,price,weight,quantity);
            return result;
        }
    }
}
