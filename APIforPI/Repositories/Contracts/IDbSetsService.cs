using APIforPI.Infrastracture.Dto;
using APIforPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Interfaces
{
    public interface IDbSetsService
    {
        /// <summary>
        /// Получает полную коллекцию сетов из БД
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Sets>> GetAllSetsAsync();
        /// <summary>
        /// Получает экземпляр сета из БД по его id
        /// </summary>
        /// <param name="id">id продукта</param>
        /// <returns></returns>
        Task<Sets> GetSetInfoAsync(int id);
        /// <summary>
        /// Создает и помещает в БД новый экземпляр сета
        /// </summary>
        /// <param name="name">Имя сета</param>
        /// <param name="price">Цена сета</param>
        /// <param name="totalAmount">Полная стоимость сета</param>
        /// <param name="sushis">Коллекция id суши, которые будут находиться в сете</param>
        /// <returns></returns>
        Task<Sets> CreateNewSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis);
        /// <summary>
        /// Удаляет сет из БД по его id
        /// </summary>
        /// <param name="setId">id сета</param>
        /// <returns></returns>
        Task DeleteSetAsync(int setId);
        /// <summary>
        /// Получает коллекцию суши по набору id для добавления в сет
        /// </summary>
        /// <param name="sushisId"></param>
        /// <returns></returns>
        Task<List<Sushi>> FindSushisForSetAsync(IEnumerable<int> sushisId);
    }
}
