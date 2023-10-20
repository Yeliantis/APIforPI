using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.Web.Services.Contracts
{
    public interface IOrderWebService
    {
        Task<Order> ExecuteOrder(IEnumerable<CartItemDto> cartItems);
    }
}
