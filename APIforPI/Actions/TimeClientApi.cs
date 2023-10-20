using APIforPI.Actions.Contracts;
using APIforPI.Infrastracture.Models;
using RestSharp;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace APIforPI.Actions
{
    public class TimeClientApi : ITimeApi
    {
        public async Task<OnlyTime?> GetYourTime()
        {
            using (RestClient client = new RestClient("http://worldtimeapi.org/"))
            {
               var s = await client.GetJsonAsync<OnlyTime?>("/api/ip");
                ParseDate(s);
                return s;
            }
        }
        public void ParseDate(OnlyTime time)
        {
            char[] separator = { 'T', '.' };
            var completeDate = time.CurrentTime.Split(separator)[0]+" " + time.CurrentTime.Split(separator)[1];
            time.Date = DateTime.Parse(completeDate);
        }
    }
}
