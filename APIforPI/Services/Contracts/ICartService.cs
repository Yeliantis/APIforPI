using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Services.Contracts
{
    public interface ICartService
    {
        Task<CartItemDto> AddItem(CartItemAddDto cartItemToAdd);
        Task<CartItemDto> UpdateQty(int id, CartItemUpdateQtyDto cartItemToUpdate);

        Task<CartItemDto> DeleteItem(int id);
        Task<CartItemDto> GetItem(int id);
        Task<IEnumerable<CartItemDto>> GetCartItems(int Id);
        Task<CartItemDto> IncreaseQtyAsync(int id);
        Task<CartItemDto> DecreaseQtyAsync(int id);
    }
}
