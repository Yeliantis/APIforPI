using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace APIforPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("MakeOrder")]
        public async Task<ActionResult<Order>> MakeOrder(IEnumerable<CartItemDto> cartItems)
        {
            var result = await _orderService.AddOrderAsync(cartItems);
            if (result == null)
            {
                return StatusCode(500, "Ошибка добавления в базу данных");
            }
            return Ok(result);
        }
    }
}
