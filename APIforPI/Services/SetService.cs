using APIforPI.Interfaces;
using APIforPI.Models;
using APIforPiInfrastracture.Interfaces;
using AutoMapper;

namespace APIforPI.Services
{
    public class SetService : ISetService
    {
        private readonly IDatabaseService _databaseService;
        
        public SetService(IDatabaseService databaseService)
        {
            _databaseService= databaseService;
        }

        public void ChangeSet(string name, int price, int totalAmount, IEnumerable<int> sushis)
        {
           _databaseService.UpdateSet(name, price, totalAmount, sushis);
        }

        public void CreateNewSet(string name, int price, int totalAmount, IEnumerable<int> sushis)
        {
            _databaseService.CreateNewSet(name,  price,  totalAmount, sushis);
        }

        public ICollection<Sets> GetAllSets()
        {
           return _databaseService.GetAllSets();
        }

        public Sets GetSetInformation(string name)
        {
            return _databaseService.GetSetInfo(name);
        }
        public void DeleteSet(string name)
        {
             _databaseService.DeleteSet(name);
        }

    }
}
