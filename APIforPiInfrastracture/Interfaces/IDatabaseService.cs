using APIforPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace APIforPiInfrastracture.Interfaces
{
    public interface IDatabaseService
    {
        ICollection<Sushi> GetAllSushis();
        Sushi GetSushiWithId(int id);
        Sushi GetSushi(string name);

        ICollection<Sushi> FindSushisForSet(IEnumerable<int> sushisId);
        void CreateSushi(string name, int price, int weight, int quantity);

        bool SUshiExists(int sushiId);
        ICollection<Sets> GetAllSets();
        Sets GetSetInfo(string name);

        //Sets GetAlternative(string name);
        void CreateNewSet(string name, int price, int totalAmount, IEnumerable<int> sushis);
        void UpdateSet(string name, int price, int totalAmount, IEnumerable<int> sushis);
        void DeleteSet(string name);
    }
}
