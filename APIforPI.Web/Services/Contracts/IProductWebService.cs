using APIforPI.Infrastracture.Dto;
using APIforPI.Models;

namespace APIforPI.Web.Services.Contracts
{
    public interface IProductWebService
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItem(int id);
        Task<SushiDto> GetSushi(int id);
        Task<SetsDto> GetSet(int id);
    }
}
