using APIforPI.Infrastracture.Interfaces;
using APIforPI.Infrastracture.Models;
using APIforPI.Interfaces;

namespace APIforPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbProductService _dbProductService;
        public ProductService(IDbProductService dbProductService)
        {
            _dbProductService = dbProductService;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
           return await _dbProductService.GetAllProductsAsync();
        }
    }
}
