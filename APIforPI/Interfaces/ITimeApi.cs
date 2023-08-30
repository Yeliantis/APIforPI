using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Interfaces
{
    public interface ITimeApi
    {
        public Task<OnlyTime> GetYourTime();
        public void ParseDate(OnlyTime time);
    }
}
