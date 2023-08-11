using APIforPI.Data;
using APIforPI.Models;
using APIforPI.Services;
using System.Runtime.ExceptionServices;

namespace APIforPI.Seed
{
    public class SeedData
    {
        //Для запуска Seed после создания базы данных прописать в Developer PowerShell папку с проектом и после: dotnet run seeddata
        private readonly DataContext _context;
        public SeedData(DataContext context)
        {
            _context = context;
        }
        
        
        public void SeedDataContext()
        {
            if (!_context.Sushi.Any())
            {
                List<Sushi> sushis = new List<Sushi>();
                sushis.AddRange(new List<Sushi>() { first,second,third,fourth,fifth,sixth,seventh,eighth,ninth,tenth,eleventh,twelfth});   
                
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
                        Sushis= new List<Sushi>() {first,second,third,fourth}
                        
                    },
                    new Sets()
                    {
                        Name = "Вкусный Сет",
                        Price = 1100,
                        TotalAmount = 24,
                        Sushis = new List<Sushi>() {fifth,sixth,eighth}
                    },
                    new Sets()
                    {
                        Name = "Знакомство Сет",
                        Price = 1800,
                        TotalAmount = 32,
                        Sushis = new List<Sushi>() {first,ninth,tenth,eleventh}
                    },
                    new Sets()
                    {
                        Name = "Красный Дракон",
                        Price = 1510,
                        TotalAmount = 24,
                        Sushis = new List<Sushi> {fifth,sixth,second }
                    }
                };
                _context.Sets.AddRange(sets);
                _context.SaveChanges();
            }
            //if (!_context.SushiSet.Any())
            //{
            //    var relations = new List<SetSushi>()
            //    {
            //        new SetSushi()
            //        {
            //            SetId = 1,
            //            SushiId = 1,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 1,
            //            SushiId = 2,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 1,
            //            SushiId = 3,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 1,
            //            SushiId = 4,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 1,
            //            SushiId = 5,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 2,
            //            SushiId = 2,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 2,
            //            SushiId = 3,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 2,
            //            SushiId = 7,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 3,
            //            SushiId = 6,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 3,
            //            SushiId = 10,
            //        },new SetSushi()
            //        {
            //            SetId = 3,
            //            SushiId = 11,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 3,
            //            SushiId = 13,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 3,
            //            SushiId = 15,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 4,
            //            SushiId = 1,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 4,
            //            SushiId = 17,
            //        },
            //        new SetSushi()
            //        {
            //            SetId = 4,
            //            SushiId = 12,
            //        }
            //    };
            //    _context.SushiSet.AddRange(relations);
            //    _context.SaveChanges();
            //}
        }
        Sushi first = new Sushi
        {
            Name = "Красный дракон",
            Quantity = 8,
            Weight = 220,
            Price = 770
        };
        Sushi second = new Sushi
        {
            Name = "Юта",
            Quantity = 8,
            Weight = 250,
            Price = 410

        };
        Sushi third = new Sushi
        {
            Name = "Осака",
            Quantity = 8,
            Weight = 240,
            Price = 470
        };
        Sushi fourth = new Sushi
        {
            Name = "Чидзу",
            Quantity = 8,
            Weight = 250,
            Price = 390
        };
        Sushi fifth = new Sushi
        {
            Name = "Самбай",
            Quantity = 8,
            Weight = 250,
            Price = 390
        };
        Sushi sixth = new Sushi
        {
            Name = "Самбай",
            Quantity = 8,
            Weight = 250,
            Price = 390
        };
        Sushi seventh = new Sushi
        {
            Name = "Солнечный",
            Quantity = 8,
            Weight = 210,
            Price = 370
        };
        Sushi eighth = new Sushi
        {
            Name = "Эвоки",
            Quantity = 8,
            Weight = 280,
            Price = 310
        };
        Sushi ninth = new Sushi
        {
            Name = "Миёк",
            Quantity = 8,
            Weight = 280,
            Price = 290
        };
        Sushi tenth = new Sushi
        {
            Name = "Вэлл Ролл",
            Quantity = 8,
            Weight = 240,
            Price = 360
        };
        Sushi eleventh = new Sushi
        {
            Name = "Калифорния с крабом",
            Quantity = 8,
            Weight = 240,
            Price = 720
        };
        Sushi twelfth = new Sushi
        {
            Name = "Баки",
            Quantity = 8,
            Weight = 270,
            Price = 360
        };
        
       
    }
    
}
