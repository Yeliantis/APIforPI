
using APIforPI.Infrastracture.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIforPI.Models
{
    public class Sets : Product
    {      
        public List<Sushi> Sushis { get; set; }
        public int TotalAmount { get; set; }
    }
}
