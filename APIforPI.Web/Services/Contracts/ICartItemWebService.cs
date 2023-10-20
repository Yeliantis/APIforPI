using APIforPI.Infrastracture.Dto;

namespace APIforPI.Web.Services.Contracts
{
    public interface ICartItemWebService
    {
        Task<IEnumerable<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemAddDto cartItemAddDto);
        Task<CartItemDto> DeleteItem(int id);
        Task<IEnumerable<CartItemDto>> ClearCartAsync(int cartId);
        Task<CartItemDto> UpdateQty(CartItemUpdateQtyDto cartItemUpdateQtyDto);
        Task<CartItemDto> IncreaseQty(int id);
        Task<CartItemDto> DecreaseQty(int id);

        event Action<string> CartChanged;

        void CallEventWhenCartChanged(string totalPrice);
    }
}
