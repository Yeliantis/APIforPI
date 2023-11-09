
using APIforPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Interfaces
{
    public interface IDbSushiService
    {
        /// <summary>
        /// Получает полную коллекцию суши из БД
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Sushi>> GetAllSushisAsync();
        /// <summary>
        /// Получает экземпляр суши из БД по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Sushi> GetSushiWithIdAsync(int id);
        /// <summary>
        /// Получает экземпляр суши из БД по его имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Sushi> GetSushiByNameAsync(string name);
        /// <summary>
        /// Создает и помещает данные о суши в БД
        /// </summary>
        /// <param name="sushi"></param>
        /// <returns></returns>
        Task<Sushi> CreateSushiAsync(Sushi sushi);
        /// <summary>
        /// Проверка, существует ли суши в бд
        /// </summary>
        /// <param name="sushiId">коллекция id суши</param>
        /// <returns></returns>
        bool SushiExists(int sushiId);
    }
}
