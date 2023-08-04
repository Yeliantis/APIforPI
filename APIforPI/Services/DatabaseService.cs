using APIforPI.Data;
using APIforPI.Dto;
using APIforPI.Models;
using APIforPiInfrastracture.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIforPI.Services
{
    public class DatabaseService : IDatabaseService
    {

        private readonly DataContext _context;

        public DatabaseService(DataContext context)
        {
            _context= context;
        }
  
        public ICollection<Sushi> GetAllSushis() => _context.Sushi.OrderBy(s => s.Id).ToList();       //Получение полного списка всех суши
        public Sushi GetSushi(string name) => _context.Sushi.Where(x => x.Name == name).FirstOrDefault();  //Получение информации о суши по имени
        public Sushi GetSushiWithId(int id) => _context.Sushi.Where(x => x.Id == id).FirstOrDefault(); //Получение информации о суши по id
        public bool SUshiExists(int sushiId) => _context.Sushi.Any(x=>x.Id== sushiId); //Проверка, существует ли такой суши
        public Sets GetSetInfo(string name) => _context.Sets.Include(c => c.Sushis).FirstOrDefault(x => x.Name == name); // Получение полной информации о конкретном сете
        
        public ICollection<Sets> GetAllSets() => _context.Sets.OrderBy(s => s.Id).Include(c=>c.Sushis).ToList(); // Получение полного списка всех сетов
        public void CreateSushi(string name, int price, int weight, int quantity) //Создание нового суши
        {
            var exists = _context.Sushi.Where(x=>x.Name==name).FirstOrDefault();
            if (exists == null)
            {
                Sushi sushi = new Sushi { Name=name, Price=price,Weight=weight,Quantity=quantity };
                _context.Sushi.Add(sushi);
                _context.SaveChanges();
            }

        }
        public void CreateNewSet(string name, int price, int totalAmount, IEnumerable<int> sushis) //Создание нового сета
        {
            if (sushis == null) throw new ArgumentException("You didn't put any sushis in your set, Sushis are null");
            var exists = _context.Sets.Where(y=>y.Name== name).FirstOrDefault();
            if (exists == null)
            {
                Sets newSet = new Sets { Name = name, Price = price, TotalAmount = totalAmount, Sushis = FindSushisForSet(sushis) };
                
                _context.Sets.Add(newSet);
                _context.SaveChanges();
            }   
        }
        public void UpdateSet(string name, int price, int totalAmount, IEnumerable<int> sushis)
        {
            var exists = _context.Sets.Where(x => x.Name == name).FirstOrDefault();
            if (exists!= null)
            {
                exists.Name = name;
                exists.Price = price;
                exists.TotalAmount = totalAmount;
                exists.Sushis = FindSushisForSet(sushis);
                _context.Sets.Update(exists);
                _context.SaveChanges();
            }
        }

        public ICollection<Sushi> FindSushisForSet(IEnumerable<int> sushisId)
        {

            ICollection<Sushi> temp = new List<Sushi>();
            foreach (var item in sushisId)
            {
                temp.Add(_context.Sushi.Where(y=>y.Id==item).FirstOrDefault());
            }

            return temp;
        }

        public void DeleteSet(string name)
        {
            _context.Remove(_context.Sets.Where(x=>x.Name==name).FirstOrDefault());
            _context.SaveChanges();
        }

        //public Sets GetAlternative(string name)
        //{
        //    var between = _context.Sets.Where(x => x.Name == name).FirstOrDefault();
        //    var id = between.Id;
        //    List<Sushi> sushiList= new List<Sushi>();
        //    using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DOCF23P\\MSSQLSERVER01;Initial Catalog=RedDragon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
        //    {
        //        connection.Open();
        //        SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM Sushi WHERE Name = 'Красный дракон'", connection);
        //        SqlDataReader reader = sqlCommand.ExecuteReader();
        //        while(reader.Read())
        //        {
        //            sushiList.Add(new Sushi()
        //            {
        //                Name = reader["Name"].ToString(),
        //                Quantity = Convert.ToInt32(reader["Quantity"]),
        //                Price = Convert.ToInt32(reader["Price"]),
        //                Weight = Convert.ToInt32(reader["Weight"])
        //            });
        //        }
        //    }
        //    between.Sushis = sushiList;
        //    return between;
        //}
        //public List<int> ToFillList(int setId) => _context.SushiSet.Where(y=>y.SetId== setId).Select(z=>z.SushiId).ToList();


    }
}
