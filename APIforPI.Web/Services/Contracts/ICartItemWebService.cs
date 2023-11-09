using APIforPI.Infrastracture.Dto;

namespace APIforPI.Web.Services.Contracts
{
    public interface ICartItemWebService
    {
        /// <summary>
        /// Получа
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<CartItemDto>> GetItems(int userId);
        /// <summary>
        /// Обращение к API, добавляет в корзину пользователя товар 
        /// </summary>
        /// <param name="cartItemAddDto">информация для добавления (cartId, userId, ProductId)</param>
        /// <returns></returns>
        Task<CartItemDto> AddItem(CartItemAddDto cartItemAddDto);
        Task<CartItemDto> DeleteItem(int id);
        /// <summary>
        /// Обращение к API, полностью убирает все товары в корзине, найденные по id корзины
        /// </summary>
        /// <param name="cartId">id корзины пользователя</param>
        /// <returns></returns>
        Task<IEnumerable<CartItemDto>> ClearCartAsync(int cartId);
        /// <summary>
        /// Обращение к API, изменяет количество одного товара в корзине на число Qty из CartItemUpdateQtyDto
        /// </summary>
        /// <param name="cartItemUpdateQtyDto"></param>
        /// <returns></returns>
        Task<CartItemDto> UpdateQty(CartItemUpdateQtyDto cartItemUpdateQtyDto);
        /// <summary>
        /// Обращение к API, увеличивает количество одного товара в корзине, найденного по id, на 1
        /// </summary>
        /// <param name="id">if товара</param>
        /// <returns></returns>
        Task<CartItemDto> IncreaseQty(int id);
        /// <summary>
        /// Обращение к API, уменьшает количество одного товара в корзине, найденного по id, на 1
        /// </summary>
        /// <param name="id">id товара в корзине</param>
        /// <returns></returns>
        Task<CartItemDto> DecreaseQty(int id);
        /// <summary>
        /// Event для изменения суммы в верхнем блоке страницы с отображением итоговой суммы
        /// </summary>

        event Action<string> CartChanged;

        void CallEventWhenCartChanged(string totalPrice);
    }
}
