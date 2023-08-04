using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIforPI.Models
{
    public class Sushi
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        [JsonIgnore]
        public ICollection<Sets> Sets { get; set; }
        //public List<Sets> setsItBelongs {get;set;}
        //public int PercentOfProfit { get; set; }
    }
}
