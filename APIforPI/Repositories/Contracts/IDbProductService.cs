using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Interfaces
{
    public interface IDbProductService
    {
        /// <summary>
        /// Получает коллекцию всех имеющихся продуктов (сетов, суши) из БД
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAllProductsAsync();
        /// <summary>
        /// Получает информацию о продукте из БД по его id
        /// </summary>
        /// <param name="id">id продукта</param>
        /// <returns></returns>
        Task<Product> GetProductAsync(int id);
    }
}
