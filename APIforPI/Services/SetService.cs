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

        public async Task ChangeSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis)
        {
           await _dbSetsService.UpdateSetAsync(name, price, totalAmount, sushis);
        }

        public async Task CreateNewSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis)
        {
            await _dbSetsService.CreateNewSetAsync(name,  price,  totalAmount, sushis);
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
        public async Task DeleteSetAsync(string name)
        {
            await _dbSetsService.DeleteSetAsync(name);
        }

    }
}
