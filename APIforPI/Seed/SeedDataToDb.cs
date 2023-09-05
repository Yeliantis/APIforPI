using APIforPI.Data;
using APIforPI.Models;
using APIforPI.Services;
using System.Runtime.ExceptionServices;

namespace APIforPI.Seed
{
    public class SeedDataToDb
    {
        //Для запуска Seed после создания базы данных прописать в Developer PowerShell папку с проектом и после: dotnet run seeddata
        private readonly DataContext _context;
        public SeedDataToDb(DataContext context)
        {
            _context = context;
        }
        
        
        public void SeedDataContext()
        {
            if (!_context.Sushi.Any())
            {
                List<Sushi> sushis = new List<Sushi>();
                sushis.AddRange(new List<Sushi>() { first,second,third,fourth,fifth,seventh,eighth,ninth,tenth,eleventh,twelfth});   
                
                _context.Sushi.AddRange(sushis);
                _context.SaveChanges();
            }
            if (!_context.Sets.Any())
            {

                var sets = new List<Sets>()
                {
                    new Sets()
                    {
                        Name = "Бум Сет",
                        Price = 2100,
                        TotalAmount = 32,
                        Sushis= new List<Sushi>() {first,second,third,fourth},
                        ImageURL = "/Images/Rolls/Сет.jpg",
                        Category = "Set"

                    },
                    new Sets()
                    {
                        Name = "Вкусный Сет",
                        Price = 1100,
                        TotalAmount = 24,
                        Sushis = new List<Sushi>() {fifth,eighth,ninth},
                        ImageURL = "/Images/Rolls/Сет.jpg",
                        Category = "Set"
                    },
                    new Sets()
                    {
                        Name = "Знакомство Сет",
                        Price = 1800,
                        TotalAmount = 32,
                        Sushis = new List<Sushi>() {first,ninth,tenth,eleventh},
                        ImageURL = "/Images/Rolls/Сет.jpg",
                        Category = "Set"
                    },
                    new Sets()
                    {
                        Name = "Красный Дракон",
                        Price = 1510,
                        TotalAmount = 24,
                        Sushis = new List<Sushi> {fifth,third,second },
                        ImageURL = "/Images/Rolls/Сет.jpg",
                        Category = "Set"
                    }
                };
                _context.Sets.AddRange(sets);
                _context.SaveChanges();
            }
            
        }
        Sushi first = new Sushi
        {
            Name = "Красный дракон",
            Quantity = 8,
            Weight = 220,
            Price = 770,
            ImageURL = "/Images/Rolls/Красный дракон.jpg",
            Category = "Sushi"
        };
        Sushi second = new Sushi
        {
            Name = "Юта",
            Quantity = 8,
            Weight = 250,
            Price = 410,
            ImageURL = "/Images/Rolls/Юта.jpg",
            Category = "Sushi"

        };
        Sushi third = new Sushi
        {
            Name = "Осака",
            Quantity = 8,
            Weight = 240,
            Price = 470,
            ImageURL = "/Images/Rolls/Осака.jpg",
            Category = "Sushi"
        };
        Sushi fourth = new Sushi
        {
            Name = "Чидзу",
            Quantity = 8,
            Weight = 250,
            Price = 390,
            ImageURL = "/Images/Rolls/Чидзу.jpg",
            Category = "Sushi"
        };
        Sushi fifth = new Sushi
        {
            Name = "Самбай",
            Quantity = 8,
            Weight = 250,
            Price = 390,
            ImageURL = "/Images/Rolls/Самбай.jpg",
            Category = "Sushi"
        };
        
        Sushi seventh = new Sushi
        {
            Name = "Солнечный",
            Quantity = 8,
            Weight = 210,
            Price = 370,
            ImageURL = "/Images/Rolls/Солнечный.jpg",
            Category = "Sushi"
        };
        Sushi eighth = new Sushi
        {
            Name = "Эвоки",
            Quantity = 8,
            Weight = 280,
            Price = 310,
            ImageURL = "/Images/Rolls/Эвоки.jpg",
            Category = "Sushi"
        };
        Sushi ninth = new Sushi
        {
            Name = "Миёк",
            Quantity = 8,
            Weight = 280,
            Price = 290,
            ImageURL = "/Images/Rolls/Миёк.jpg",
            Category = "Sushi"
        };
        Sushi tenth = new Sushi
        {
            Name = "Вэлл Ролл",
            Quantity = 8,
            Weight = 240,
            Price = 360,
            ImageURL = "/Images/Rolls/Вэлл Ролл.jpg",
            Category = "Sushi"
        };
        Sushi eleventh = new Sushi
        {
            Name = "Калифорния с крабом",
            Quantity = 8,
            Weight = 240,
            Price = 720,
            ImageURL = "/Images/Rolls/Калифорния с крабом.jpg",
            Category = "Sushi"
        };
        Sushi twelfth = new Sushi
        {
            Name = "Баки",
            Quantity = 8,
            Weight = 270,
            Price = 360,
            ImageURL = "/Images/Rolls/Баки.jpg",
            Category = "Sushi"
        };
        
       
    }
    
}
