using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Services.Contracts
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(IEnumerable<CartItemDto> cartItem);
    }
}
