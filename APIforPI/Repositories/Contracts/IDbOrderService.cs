using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Repositories.Contracts
{
    public interface IDbOrderService
    {
        /// <summary>
        /// Создает в БД информацию об сделанно заказе
        /// </summary>
        /// <param name="cartItem">Продукты, имеющиеся в заказе</param>
        /// <returns></returns>
        Task<Order> AddOrderAsync(IEnumerable<CartItemDto> cartItem);
        /// <summary>
        /// Создает в таблице деталей заказа n-ное кол-во записей со всеми имеющимися продуктами
        /// </summary>
        /// <param name="cartItems">n-ное кол-во продуктов в заказе</param>
        /// <param name="orderId">id заказа</param>
        /// <returns></returns>
        Task<IEnumerable<OrderDetails>> AddOrderDetailsAsync(IEnumerable<CartItemDto> cartItems, int orderId);
        /// <summary>
        /// Получает информацию о заказе из БД по id заказа
        /// </summary>
        /// <param name="id">id заказа</param>
        /// <returns></returns>
        Task<Order> GetOrderByIdAsync(int id);
    }
}
