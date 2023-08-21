using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Interfaces
{
    public interface ITimeApi
    {
        public Task<OnlyTime> GetYourTime();
        public Task<string[]> ParseDate(string date);
    }
}
