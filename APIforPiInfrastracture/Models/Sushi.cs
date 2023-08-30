using APIforPI.Infrastracture.Interfaces;
using APIforPI.Infrastracture.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIforPI.Models
{
    public class Sushi : Product
    {
        
        public int Quantity { get; set; }
        public int Weight { get; set; }
        [JsonIgnore]
        public List<Sets> Sets { get; set; }
    }
}
