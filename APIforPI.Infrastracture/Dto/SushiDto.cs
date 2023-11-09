using System.ComponentModel.DataAnnotations;

namespace APIforPI.Infrastracture.Dto
{
    public class SushiDto
    {


        public string Name { get; set; } 
        public int Id { get; set; }

        public int Weight { get; set; }
   
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageURL { get; set; } = string.Empty;
    }
}
