using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Actions.Contracts
{
    public interface ITimeApi
    {
        public Task<OnlyTime> GetYourTime();
        public void ParseDate(OnlyTime time);
    }
}
