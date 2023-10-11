using APIforPI.DtoConversions;
using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Interfaces;
using APIforPI.Infrastracture.Models;
using APIforPI.Services.Contracts;
using AutoMapper;

namespace APIforPI.Services
{
    public class CartService : ICartService
    {
        private readonly IDbCartItemService _cartItemDbService;
        private readonly IDbProductService _productDbService;
        public CartService(IDbCartItemService cartItemService, IDbProductService productService)
        {
            _cartItemDbService = cartItemService;
            _productDbService = productService;
           
        }
        public async Task<CartItemDto> AddItem(CartItemAddDto cartItemToAdd)
        {
            var noDto = await _cartItemDbService.AddItem(cartItemToAdd);
            if (noDto!=null)
            {
                var product = await _productDbService.GetProductAsync(noDto.ProductId); //Пофиксить баг при попытке добавить один и тот же предмет
                var result = noDto.ConvertToDto(product);
                return result;
            }
            return null;
        }

        public async Task<CartItemDto> DeleteItem(int id)
        {
            var noDto = await _cartItemDbService.DeleteItem(id);
            var product = await _productDbService.GetProductAsync(noDto.ProductId);
            var result = noDto.ConvertToDto(product);
            return result;
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItems(int id)
        {
            var noDto = await _cartItemDbService.GetCartItems(id);
            var products = await _productDbService.GetAllProductsAsync();
            var result = noDto.ConvertToDto(products);
            return result;
        }

        public async Task<CartItemDto> GetItem(int id)
        {
            var noDto = await _cartItemDbService.GetItem(id);
            var product = await _productDbService.GetProductAsync(noDto.ProductId);
            var result = noDto.ConvertToDto(product);
            return result;
        }

       
        public async Task<CartItemDto> UpdateQty(int id, CartItemUpdateQtyDto cartItemToUpdate)
        {
            var noDto = await _cartItemDbService.UpdateQty(id, cartItemToUpdate);
            var product = await _productDbService.GetProductAsync(noDto.ProductId);
            var result = noDto.ConvertToDto(product);
            return result;
        }
        public async Task<CartItemDto> IncreaseQtyAsync(int id)
        {
            var noDto = await _cartItemDbService.IncreaseQty(id);
            var produt = await _productDbService.GetProductAsync(noDto.ProductId);
            var result = noDto.ConvertToDto(produt);
            return result;
        }

        public async Task<CartItemDto> DecreaseQtyAsync(int id)
        {
            var noDto = await _cartItemDbService.DecreaseQty(id);
            var product = await _productDbService.GetProductAsync(noDto.ProductId);
            var result = noDto.ConvertToDto(product);
            return result;
        }
    }
}
