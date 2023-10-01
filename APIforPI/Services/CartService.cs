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
        private readonly IDbCartItemService _cartItemService;
        private readonly IDbProductService _productService;
        public CartService(IDbCartItemService cartItemService, IDbProductService productService)
        {
            _cartItemService = cartItemService;
            _productService = productService;
           
        }
        public async Task<CartItemDto> AddItem(CartItemAddDto cartItemToAdd)
        {
            var noDto = await _cartItemService.AddItem(cartItemToAdd);
            var product = await _productService.GetProductAsync(noDto.ProductId); //Пофиксить баг при попытке добавить один и тот же предмет
            var result = noDto.ConvertToDto(product);
            return result;
        }

        public async Task<CartItemDto> DeleteItem(int id)
        {
            var noDto = await _cartItemService.DeleteItem(id);
            var product = await _productService.GetProductAsync(noDto.ProductId);
            var result = noDto.ConvertToDto(product);
            return result;
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItems(int id)
        {
            var noDto = await _cartItemService.GetCartItems(id);
            var products = await _productService.GetAllProductsAsync();
            var result = noDto.ConvertToDto(products);
            return result;
        }

        public async Task<CartItemDto> GetItem(int id)
        {
            var noDto = await _cartItemService.GetItem(id);
            var product = await _productService.GetProductAsync(noDto.ProductId);
            var result = noDto.ConvertToDto(product);
            return result;
        }

       
        public async Task<CartItemDto> UpdateQty(int id, CartItemUpdateQtyDto cartItemToUpdate)
        {
            var noDto = await _cartItemService.UpdateQty(id, cartItemToUpdate);
            var product = await _productService.GetProductAsync(noDto.ProductId);
            var result = noDto.ConvertToDto(product);
            return result;
        }
    }
}
