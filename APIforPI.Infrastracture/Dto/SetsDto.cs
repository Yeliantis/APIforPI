using APIforPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Dto
{
    public class SetsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sushi> Sushis { get; set; }
        public decimal Price { get; set; }
        public int TotalAmount { get; set; }
        public string ImageURL { get; set; }
    }
}
