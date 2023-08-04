using APIforPI.Dto;
using APIforPI.Interfaces;
using APIforPI.Models;
using APIforPiInfrastracture.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIforPI.Services
{
    public class SushiService : ISushiService
    {

        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        public SushiService(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService= databaseService;
            _mapper= mapper;
        }
        public IEnumerable<SushiDto> GetSushis()
        {
            var sushi = _mapper.Map<List<SushiDto>>(_databaseService.GetAllSushis());
            return sushi;
        }

        public SushiDto GetSushiByName(string name)
        {
            var sushi = _mapper.Map<SushiDto>(_databaseService.GetSushi(name));
            return sushi;
        }

        public SushiDto GetSushi(int id) => _mapper.Map<SushiDto>(_databaseService.GetSushiWithId(id));

        public void CreateSushi(string name, int price, int weight, int quantity)
        {
            _databaseService.CreateSushi(name,price,weight,quantity);
            //var sushi = new Sushi { Name = name, Quantity = quantity, Weight = weight, Price =price };
           /* if (_databaseService.GetSushi(sushi.Name) != null)/* return null;*/
            //_databaseService.
            //return sushi;
        }
    }
}
