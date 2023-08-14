using APIforPI.Data;

using APIforPI.Infrastracture.Interfaces;
using APIforPI.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIforPI.Services
{
    public class DatabaseService : IDbSushiService, IDbSetsService
    {

        private readonly DataContext _context;

        public DatabaseService(DataContext context)
        {
            _context= context;
        }

        public async Task<IEnumerable<Sushi>> GetAllSushisAsync() => await _context.Sushi.OrderBy(s => s.Id).ToListAsync(); ///Получение полного списка всех суши

        public async Task<Sushi> GetSushiAsync(string name) =>await _context.Sushi.Where(x => x.Name == name).FirstOrDefaultAsync();  ///Получение информации о суши по имени
        public async Task <Sushi> GetSushiWithIdAsync(int id) => await _context.Sushi.Where(x => x.Id == id).FirstOrDefaultAsync(); ///Получение информации о суши по id
        public bool SUshiExists(int sushiId) => _context.Sushi.Any(x=>x.Id== sushiId); ///Проверка, существует ли суши
        
        
        public async Task<IEnumerable<Sets>> GetAllSetsAsync() => await _context.Sets.OrderBy(s => s.Id).Include(c=>c.Sushis).ToListAsync(); /// Получение полного списка всех сетов
        public async Task<Sushi> CreateSushiAsync(string name, int price, int weight, int quantity) ///Создание нового суши
        {
            var exists = await _context.Sushi.Where(x=>x.Name==name).FirstOrDefaultAsync();
            if (exists == null)
            {
                Sushi sushi = new Sushi { Name=name, Price=price,Weight=weight,Quantity=quantity };
                _context.Sushi.Add(sushi);
                _context.SaveChanges();
                return sushi;
            }
            return null;

        }
        public async Task CreateNewSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis) ///Создание нового сета
        {
            if (sushis == null) throw new ArgumentException("You didn't put any sushis in your set, Sushis are null");
            var exists =await _context.Sets.Where(y=>y.Name== name).FirstOrDefaultAsync();
            if (exists == null)
            {
                Sets newSet = new Sets { Name = name, Price = price, TotalAmount = totalAmount, Sushis = await FindSushisForSetAsync(sushis) };
                
                _context.Sets.Add(newSet);
                _context.SaveChanges();
            }   
        }
        public async Task UpdateSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis) /// Изменение сета по имени
        {
            var exists = await _context.Sets.Where(x => x.Name == name).FirstOrDefaultAsync();
            if (exists!= null)
            {
                exists.Name = name;
                exists.Price = price;
                exists.TotalAmount = totalAmount;
                exists.Sushis = await FindSushisForSetAsync(sushis);
                _context.Sets.Update(exists);
                _context.SaveChanges();
            }
        }

        public async Task<List<Sushi>> FindSushisForSetAsync(IEnumerable<int> sushisId) ///Полученин коллекции сетов для создания нового Сета
        {

            List<Sushi> temp = new List<Sushi>();
            foreach (var item in sushisId)
            {
                temp.Add(await _context.Sushi.Where(y=>y.Id==item).FirstOrDefaultAsync());
            }

            return temp;
        }

        public async Task<Sets> GetSetInfoAsync(string name) => await _context.Sets.Include(c => c.Sushis)
            .FirstOrDefaultAsync(x => x.Name == name); /// Получение полной информации о конкретном сете
        public async Task DeleteSetAsync(string name) /// Удаление сета по имени
        {
           _context.Remove(await _context.Sets.Where(x=>x.Name==name).FirstOrDefaultAsync());
            _context.SaveChanges();
        }
    }
}
