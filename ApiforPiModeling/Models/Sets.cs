using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIforPI.Models
{
    public class Sets
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Sushi> Sushis { get; set; }
        public int Price { get; set; }
        public int TotalAmount { get; set; }
    }
}
