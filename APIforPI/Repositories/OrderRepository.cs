using APIforPI.Actions;
using APIforPI.Actions.Contracts;
using APIforPI.Data;
using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIforPI.Repositories
{
    public class OrderRepository : IDbOrderService
    {
        private readonly DataContext _context;
        private readonly ITimeApi _timeApi;
        public OrderRepository(DataContext context, ITimeApi timeApi)
        {
            _context = context;
            _timeApi = timeApi;
        }
        public async Task<Order> AddOrderAsync(IEnumerable<CartItemDto> cartItems)
        {
            if (cartItems != null)
            {
                var item = await _timeApi.GetYourTime();
                Order order = new Order
                {
                    UserId = 1,
                    OrderPrice = cartItems.Sum(x => x.TotalPrice),
                    OrderDate = item.Date,
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                await AddOrderDetailsAsync(cartItems, order.Id);
                return order;
            }
            return null;
        }

        public async Task<IEnumerable<OrderDetails>> AddOrderDetailsAsync(IEnumerable<CartItemDto> cartItems, int orderId)
        {
            var order = await GetOrderByIdAsync(orderId);
            if (order != null && cartItems!=null)
            {
                List<OrderDetails> orderDetails = new List<OrderDetails>();
                {
                    foreach (var item in cartItems)
                    {
                        orderDetails.Add(new OrderDetails
                        {
                            OrderId = orderId,
                            ProductId = item.ProductId,
                            Qty = item.Qty,
                            TotalPrice = item.TotalPrice
                        });
                    }
                }
               await _context.OrderDetails.AddRangeAsync(orderDetails);
                await _context.SaveChangesAsync();
                return orderDetails;
                
            }
            return null;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var check = await _context.Orders
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return check;
        }


    }
}
