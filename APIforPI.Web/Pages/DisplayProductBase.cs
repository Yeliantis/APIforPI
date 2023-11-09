using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Web.Services;
using APIforPI.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;

namespace APIforPI.Web.Pages
{
    public class DisplayProductBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
        [Inject]
        public ICartItemsLocalStorageService _cartItemsLocalStorageService {get;set;}
        [Parameter]
        public CultureInfo culture { get; set; }
        [Inject]
        public ICartItemWebService CartItemWebService { get; set; }
        
       
        protected async Task AddToCart_Click(CartItemAddDto cartItemAddDto)
        {
            var cartItemDto = await CartItemWebService.AddItem(cartItemAddDto);
            
            var cartItems = await CartItemWebService.GetItems(TemporaryUser.UserId);
            await _cartItemsLocalStorageService.SaveCollection(cartItems);
            var totalPrice = cartItems.Sum(x => x.TotalPrice);
            CartItemWebService.CallEventWhenCartChanged(totalPrice.ToString("C",new CultureInfo("Ru-ru")));
          
        }
    }
}
