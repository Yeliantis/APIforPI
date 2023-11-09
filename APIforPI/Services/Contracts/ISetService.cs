using APIforPI.Infrastracture.Dto;
using APIforPI.Models;

namespace APIforPI.Services.Contracts
{
    public interface ISetService
    {
        Task<IEnumerable<SetsDto>> GetAllSetsAsync();
        Task<SetsDto> GetSetInformationAsync(int id);
        Task<Sets> CreateNewSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis);
        Task DeleteSetAsync(int setId);
    }
}
