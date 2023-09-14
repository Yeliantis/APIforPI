﻿using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Services.Contracts
{
    public interface ICartService
    {
        Task<CartItemDto> AddItem(CartItemAddDto cartItemToAdd);
        Task<CartItemDto> UpdateQty(int id, CartItemAddDto cartItemToUpdate);

        Task<CartItemDto> DeleteItem(int id);
        Task<CartItemDto> GetItem(int id);
        Task<IEnumerable<CartItemDto>> GetCartItems(int Id);
    }
}