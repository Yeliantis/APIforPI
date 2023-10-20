using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Repositories.Contracts;
using APIforPI.Services.Contracts;

namespace APIforPI.Services
{
    public class OrderService : IOrderService
    {
        private IDbOrderService _dbOrderService;
        public OrderService(IDbOrderService dbOrderService)
        {
            _dbOrderService = dbOrderService;
        }
        public async Task<Order> AddOrderAsync(IEnumerable<CartItemDto> cartItem)
        {
            var result = await _dbOrderService.AddOrderAsync(cartItem);
            return result;
        }

       
    }
}
