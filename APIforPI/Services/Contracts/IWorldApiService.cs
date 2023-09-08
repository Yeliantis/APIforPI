using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Services.Contracts
{
    public interface IWorldApiService
    {
        public Task<OnlyTimeDto> GetYourTime();
    }
}
