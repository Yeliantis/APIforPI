using APIforPI.Actions.Contracts;
using APIforPI.Infrastracture.Models;
using RestSharp;
using static System.Net.Mime.MediaTypeNames;

namespace APIforPI.Actions
{
    public class TimeClientApi : ITimeApi
    {
        public async Task<OnlyTime?> GetYourTime()
        {
            var options = new RestClientOptions("http://worldtimeapi.org/");
            var client = new RestClient(options);
          
            var s = await client.GetJsonAsync<OnlyTime?>("/api/ip");
            
             ParseDate(s);
            
            return s;
        }
        public void ParseDate(OnlyTime time)
        {     
            char[] separator = { 'T', '.' };
            time.CurrentTime = time.DateTime.Split(separator)[0];
            time.CurrentDate = time.DateTime.Split(separator)[1];    
        }
    }
}
