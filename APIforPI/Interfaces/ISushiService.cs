using APIforPI.Dto;
using APIforPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIforPI.Interfaces
{
    public interface ISushiService
    {
        public IEnumerable<SushiDto> GetSushis();
        public SushiDto GetSushiByName(string name);
        public SushiDto GetSushi(int id);
        public void CreateSushi(string name, int price, int weight, int quantity);
        
    }
}
