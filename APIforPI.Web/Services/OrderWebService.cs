using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Web.Services.Contracts;
using System.Net.Http;
using System.Net.Http.Json;

namespace APIforPI.Web.Services
{
    public class OrderWebService : IOrderWebService
    {
        private readonly HttpClient _httpClient;
        public OrderWebService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Order> ExecuteOrder(IEnumerable<CartItemDto> cartItems)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Order/MakeOrder", cartItems);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<Order>();
            }
            return null;
        }
    }
}
