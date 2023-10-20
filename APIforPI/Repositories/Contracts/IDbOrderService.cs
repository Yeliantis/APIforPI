using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Repositories.Contracts
{
    public interface IDbOrderService
    {
        Task<Order> AddOrderAsync(IEnumerable<CartItemDto> cartItem);
        Task<IEnumerable<OrderDetails>> AddOrderDetailsAsync(IEnumerable<CartItemDto> cartItems, int orderId);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
