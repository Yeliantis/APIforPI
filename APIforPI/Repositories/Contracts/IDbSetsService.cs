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
        Task<IEnumerable<Sets>> GetAllSetsAsync();
        Task<Sets> GetSetInfoAsync(int id);
        Task CreateNewSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis);
        Task UpdateSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis);
        Task DeleteSetAsync(string name);
        Task<List<Sushi>> FindSushisForSetAsync(IEnumerable<int> sushisId);
    }
}
