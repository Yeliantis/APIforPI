using APIforPI.Infrastracture.Models;
using APIforPI.Interfaces;
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
            string[] temporaryDate = await ParseDate(s.DateTime);
            s.CurrentDate = temporaryDate[0];
            s.CurrentTime = temporaryDate[1];
            return s;
        }
        public async Task<string[]> ParseDate(string date)
        {
            string[] result = new string[2];
            char[] separator = { 'T', '.' };
            var first = date.Split(separator)[0];
            var second = date.Split(separator)[1];

            return new string[] { first, second };
        }
    }
}
