using APIforPI.Infrastracture.Dto;
using APIforPI.Models;

namespace APIforPI.Web.Services.Contracts
{
    public interface IProductWebService
    {
        /// <summary>
        /// Отправляет запрос к API для получения коллекции всех существующих продуктов
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductDto>> GetItems();
        /// <summary>
        /// Отправляет запрос к API для получения продукта по его id
        /// </summary>
        /// <param name="id">id продукта в БД</param>
        /// <returns></returns>
        Task<ProductDto> GetItem(int id);
        /// <summary>
        /// Отправляет запрос к API для получения суши по его id
        /// </summary>
        /// <param name="id">id суши в БД</param>
        /// <returns></returns>
        Task<SushiDto> GetSushi(int id);
        /// <summary>
        /// Отправляет запрос к API для получения сета по его id
        /// </summary>
        /// <param name="id">id сета в БД</param>
        /// <returns></returns>
        Task<SetsDto> GetSet(int id);
    }
}
