using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Interfaces
{
    public interface IDbCartItemService
    {
        /// <summary>
        /// Добавляет в корзину пользователя единицу товара В БД
        /// </summary>
        /// <param name="cartItemToAdd">информация о продукте</param>
        /// <returns></returns>
        Task<CartItem> AddItem(CartItemAddDto cartItemToAdd);
        /// <summary>
        /// Меняет кол-во конкретного товара в корзине пользователя в БД
        /// </summary>
        /// <param name="id">id товара</param>
        /// <param name="cartItemToUpdate">(id корзины,id продукта, кол-во)</param>
        /// <returns></returns>

        Task<CartItem> UpdateQty(int id, CartItemUpdateQtyDto cartItemToUpdate);
        /// <summary>
        /// Удаляет продукт из корзины пользователя в БД
        /// </summary>
        /// <param name="cartItemId"></param>
        /// <returns></returns>
        Task<CartItem> DeleteItem(int cartItemId);
        /// <summary>
        /// Получает информацию о товаре в корзине пользователя из БД
        /// </summary>
        /// <param name="userCartId">id продукта в корзине</param>
        /// <returns></returns>
        Task<CartItem> GetItem(int userCartId);
        /// <summary>
        /// Получает коллекцию всех товаров в корзине пользователя из БД
        /// </summary>
        /// <param name="Id">id корзины пользователя</param>
        /// <returns></returns>
        Task<IEnumerable<CartItem>> GetCartItems(int userCartId);
        /// <summary>
        /// Увеличивает кол-во товара на 1 в БД 
        /// </summary>
        /// <param name="cartItemId">id товара в корзине</param>
        /// <returns></returns>
        Task<CartItem> IncreaseQty(int cartItemId);
        /// <summary>
        /// Уменьшает кол-во товара на 1 в БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CartItem> DecreaseQty(int id);
        /// <summary>
        /// Полностью удаляет все товары из корзины пользователя в БД
        /// </summary>
        /// <param name="cartId">id корзины пользователя</param>
        /// <returns></returns>

        Task<IEnumerable<CartItem>> ClearCart(int cartId);

    }
}
