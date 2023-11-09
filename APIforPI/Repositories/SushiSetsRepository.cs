using APIforPI.Data;
using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Interfaces;
using APIforPI.Infrastracture.Models;
using APIforPI.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIforPI.DbServices
{
    public class SushiSetsRepository : IDbSushiService, IDbSetsService, IDbProductService
    {

        private readonly DataContext _context;

        public SushiSetsRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Sushi>> GetAllSushisAsync() => await _context
            .Sushi.OrderBy(s => s.Id).ToListAsync(); 

        public async Task<Sushi> GetSushiByNameAsync(string name) => await _context.Sushi
            .Where(x => x.Name == name).FirstOrDefaultAsync();
        public async Task<Sushi> GetSushiWithIdAsync(int id) => await _context.Sushi
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        public bool SushiExists(int sushiId) => _context.Sushi
            .Any(x => x.Id == sushiId);

        public async Task<IEnumerable<Sets>> GetAllSetsAsync() => await _context.Sets
            .OrderBy(s => s.Id).Include(c => c.Sushis).ToListAsync();
        public async Task<Sushi> CreateSushiAsync(Sushi sushi)
        {
            var exists = await _context.Sushi.Where(x => x.Name == sushi.Name).FirstOrDefaultAsync();
            if (exists == null)
            {
                _context.Sushi.Add(sushi);
                _context.SaveChanges();
                return sushi;
            }
            return null;

        }
        
        public async Task<Sets> CreateNewSetAsync(string name, int price, int totalAmount, IEnumerable<int> sushis) 
        {
            if (sushis == null) throw new ArgumentException("You didn't put any sushis in your set, Sushis are null");
            var exists = await _context.Sets.Where(y => y.Name == name).FirstOrDefaultAsync();
            if (exists == null)
            {
                Sets newSet = new Sets
                {
                    Name = name,
                    Price = price,
                    TotalAmount = totalAmount,
                    Sushis = await FindSushisForSetAsync(sushis),
                    Category="Set",
                    ImageURL= "/Images/Rolls/Сет.jpg"

                };

                _context.Sets.Add(newSet);
                _context.SaveChanges();
                return newSet;
            }
            return null;
        }

       
        public async Task<List<Sushi>> FindSushisForSetAsync(IEnumerable<int> sushisId) 
        {

            List<Sushi> temp = new List<Sushi>();
            foreach (var item in sushisId)
            {
                temp.Add(await _context.Sushi.Where(y => y.Id == item).FirstOrDefaultAsync());
            }

            return temp;
        }
        
        public async Task<Sets> GetSetInfoAsync(int id) => await _context.Sets.Include(c => c.Sushis)
            .FirstOrDefaultAsync(x => x.Id == id); 
        public async Task DeleteSetAsync(int setId)
        {
            _context.Remove(await _context.Sets.Where(x => x.Id==setId).FirstOrDefaultAsync());
            _context.SaveChanges();
        }
        
        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _context.Products
            .OrderBy(x => x.Id).ToListAsync();

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products
            .FindAsync(id);
        }
    }
}
