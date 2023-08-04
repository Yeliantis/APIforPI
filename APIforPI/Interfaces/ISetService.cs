using APIforPI.Models;

namespace APIforPI.Interfaces
{
    public interface ISetService
    {
        Sets GetSetInformation(string name);
       

        void CreateNewSet(string name, int price, int totalAmount, IEnumerable<int> sushis);
        ICollection<Sets> GetAllSets();
        void ChangeSet(string name, int price, int totalAmount, IEnumerable<int> sushis);
        void DeleteSet(string name);
    }
}
