using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Interfaces
{
    public interface IWorldApiService
    {
        public Task<OnlyTimeDto> GetYourTime();
    }
}
