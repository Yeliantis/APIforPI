using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Actions.Contracts
{
    public interface ITimeApi
    {
        /// <summary>
        /// Обращается к внешней API (WorldTimeApi) для получения локального времени по ip пользователя
        /// </summary>
        /// <returns></returns>
        public Task<OnlyTime> GetYourTime();
        /// <summary>
        /// Преобразует полученные с внешней API данные в нужный формат
        /// </summary>
        /// <param name="time"></param>
        public void ParseDate(OnlyTime time);
    }
}
