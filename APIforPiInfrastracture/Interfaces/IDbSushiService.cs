
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
        Task<IEnumerable<Sushi>> GetAllSushisAsync();
        Task<Sushi> GetSushiWithIdAsync(int id);
        Task<Sushi> GetSushiAsync(string name);
        Task<Sushi> CreateSushiAsync(string name, int price, int weight, int quantity);
        bool SUshiExists(int sushiId);
    }
}
