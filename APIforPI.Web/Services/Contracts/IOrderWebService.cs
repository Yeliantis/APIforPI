using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Web.Services.Contracts
{
    public interface IOrderWebService
    {
        /// <summary>
        /// Обращение к API, создание заказа и его деталей
        /// </summary>
        /// <param name="cartItems">товары в корзине пользователя</param>
        /// <returns></returns>
        Task<Order> ExecuteOrder(IEnumerable<CartItemDto> cartItems);
    }
}
