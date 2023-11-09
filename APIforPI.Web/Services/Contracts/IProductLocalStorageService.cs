using APIforPI.Infrastracture.Dto;
using Blazored.LocalStorage;

namespace APIforPI.Web.Services.Contracts
{
    public interface IProductLocalStorageService
    {
        /// <summary>
        /// /// Получает коллекцию всех имеющихся продуктов из локального хранилища, если она пустая - обращается к API для получения и записывает ее в локальное хранилище
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductDto>> GetCollection();
        /// <summary>
        /// Очищает все продукты в локальном хранилище
        /// </summary>
        /// <returns></returns>
        Task RemoveCollection();

    }
}
