using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Models
{
    public class OnlyTime
    {
        [JsonPropertyName("Abbreviation")]
        public string Region { get; set; }
        [JsonPropertyName("Day_Of_Week")]
        public int DayOfWeek { get; set; }
        [JsonPropertyName("Day_Of_Year")]
        public int DayOfYear { get; set; }
        public string TimeZone { get; set; }
        
        public string DateTime { get; set; }
        public string CurrentTime { get; set; }
        public string CurrentDate { get; set; }
    }
}
