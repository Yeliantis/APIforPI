using APIforPI.Infrastracture.Dto;
using APIforPI.Models;
using APIforPI.Web.Services.Contracts;
using System.Net.Http.Json;

namespace APIforPI.Web.Services
{
    public class ProductWebService : IProductWebService
    {
        private readonly HttpClient _httpClient;
        public ProductWebService(HttpClient httpClient)
        {
            _httpClient= httpClient;
        }

        public async Task<ProductDto> GetItem(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductDto>($"api/Product/{id}");
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
        }

        public async Task<SushiDto> GetSushi(int id)
        {
            return await _httpClient.GetFromJsonAsync<SushiDto>($"api/SetSushi/{id}");
        }
        public async Task<SetsDto> GetSet(int id)
        {
            return await _httpClient.GetFromJsonAsync<SetsDto>($"api/SetSushi/SetByName/{id}");
        }
    }
}
