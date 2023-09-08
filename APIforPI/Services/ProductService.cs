using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Interfaces;
using APIforPI.Infrastracture.Models;
using APIforPI.Services.Contracts;
using AutoMapper;
using System.Collections.Generic;

namespace APIforPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbProductService _dbProductService;
        private readonly MapperConfiguration _configuration;
        public ProductService(IDbProductService dbProductService)
        {
            _dbProductService = dbProductService;
            _configuration = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDto>());
        }
        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
           var result = await _dbProductService.GetAllProductsAsync();
            return new Mapper(_configuration).Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto> GetItemAsync(int id)
        {
            var result = await _dbProductService.GetProductAsync(id);
            return new Mapper(_configuration).Map<ProductDto>(result);
        }
    }
}
