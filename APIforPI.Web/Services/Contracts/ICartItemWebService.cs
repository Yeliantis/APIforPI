using APIforPI.Infrastracture.Dto;

namespace APIforPI.Web.Services.Contracts
{
    public interface ICartItemWebService
    {
        Task<IEnumerable<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemAddDto cartItemAddDto);
        Task<CartItemDto> DeleteItem(int id);
        Task<CartItemDto> UpdateQty(CartItemUpdateQtyDto cartItemUpdateQtyDto);

    }
}
