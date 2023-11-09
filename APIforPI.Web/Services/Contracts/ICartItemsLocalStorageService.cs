using APIforPI.Infrastracture.Dto;

namespace APIforPI.Web.Services.Contracts
{
    public interface ICartItemsLocalStorageService
    {
        /// <summary>
        /// Получает коллекцию товаров в корзине пользователя из локального хранилища, если она пустая - обращается к API Для получения и записывает ее в локальное хранилище
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CartItemDto>> GetCollection();
        /// <summary>
        /// Сохраняет изменения в локальном хранилище товаров в корзине пользователя
        /// </summary>
        /// <param name="cartItems"></param>
        /// <returns></returns>
        Task SaveCollection(IEnumerable<CartItemDto> cartItems);
        /// <summary>
        /// Очищает товары в корзине пользователя в локальном хранилище
        /// </summary>
        /// <returns></returns>
        Task RemoveCollection();

    }
}
