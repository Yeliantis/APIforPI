using APIforPI.Infrastracture.Dto;
using APIforPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIforPI.Services.Contracts
{
    public interface ISushiService
    {
        public Task<IEnumerable<SushiDto>> GetSushisAsync();
        public Task<SushiDto> GetSushiByNameAsync(string name);
        public Task<SushiDto> GetSushiByIdAsync(int id);
        public Task<Sushi> CreateSushiAsync(string name, int price, int weight, int quantity);

    }
}
