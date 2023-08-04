using Microsoft.EntityFrameworkCore;

namespace APIforPI.Models
{
    //[Keyless]
    public class SetSushi
    {
        public int Id { get; set; }
        public int SushiId { get; set; }
        public int SetId { get; set; }
       
    }
}
