﻿using APIforPI.Infrastracture.Dto;
using APIforPI.Services;
using APIforPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace APIforPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        public CartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        [HttpGet]
        [Route("{userId}/GetItems")]
        public async Task<ActionResult<IEnumerable<CartItemAddDto>>> GetItems(int userId)
        {
            var cartItemsDto = await _cartService.GetCartItems(userId);
            if (cartItemsDto == null)
            {
                return NotFound();
            }
            return Ok(cartItemsDto);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            var cartItemDto = await _cartService.GetItem(id);
            if (cartItemDto == null)
            {
                return NotFound();
            }
            return Ok(cartItemDto);
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> PostItem([FromBody]CartItemAddDto cartItemAddDto)
        {
            var newCartItem = await _cartService.AddItem(cartItemAddDto);
            if (newCartItem==null)
            {
                return NoContent();
            }
            return Ok(newCartItem);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
        {
            var deleteCartItem = await _cartService.DeleteItem(id);
            if (deleteCartItem==null)
            {
                return NotFound();
            }
            return Ok(deleteCartItem);
        }
    }
}