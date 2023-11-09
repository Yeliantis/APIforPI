using APIforPI.Models;
using APIforPI.Infrastracture.Interfaces;
using AutoMapper;

using APIforPI.Infrastracture.Dto;
using System.Xml;
using Microsoft.AspNetCore.Authentication;
using System.Security.Cryptography.X509Certificates;
using APIforPI.Services.Contracts;

namespace APIforPI.Services
{
    public class SetService : ISetService
    {
        
        private readonly IDbSetsService _dbSetsService;

        public SetService(IDbSushiService databaseService, IDbSetsService dbSetsService)
        {
            
            _dbSetsService = dbSetsService;
        }


        public async Task<Sets> CreateNewSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis)
        {
            var result = await _dbSetsService.CreateNewSetAsync(name, price, totalAmount, sushis);
            return result;
        }

        public async Task<IEnumerable<SetsDto>> GetAllSetsAsync()
        {
           var result = await _dbSetsService.GetAllSetsAsync();
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Sets, SetsDto>());
            return new Mapper(configuration).Map<IEnumerable<SetsDto>>(result);
        }

        public async Task<SetsDto> GetSetInformationAsync(int id)
        {
            var result = await _dbSetsService.GetSetInfoAsync(id);
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Sets, SetsDto>());
            var callbacl = new Mapper(configuration).Map<SetsDto>(result);
          
            return callbacl;
        }
        public async Task DeleteSetAsync(int setId)
        {
            await _dbSetsService.DeleteSetAsync(setId);
        }

    }
}
