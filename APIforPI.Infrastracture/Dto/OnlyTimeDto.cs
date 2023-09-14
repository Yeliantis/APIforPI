using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Dto
{
    public class OnlyTimeDto
    {
        public string Region { get; set; }
        public int DayOfWeek { get; set; }
        public int DayOfYear { get; set; }
        public string TimeZone { get; set; }
        public string CurrentTime { get; set; }
        public string CurrentDate { get; set; }
    }
}
