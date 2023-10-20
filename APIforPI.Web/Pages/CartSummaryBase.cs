using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using APIforPI.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Text.RegularExpressions;

namespace APIforPI.Web.Pages
{
    public class CartSummaryBase : ComponentBase
    {
        [Inject]
        public ICartItemWebService _cartItemWebService { get; set; }
        [Inject]
        public IOrderWebService _orderService { get; set; }
        public IEnumerable<CartItemDto> cartItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            cartItems = await _cartItemWebService.GetItems(TemporaryUser.UserId);
        }

        protected async Task MakeOrder_Click(IEnumerable<CartItemDto> cartItems)
        {
            if (cartItems.Count() >0)
            {
                var result = await _orderService.ExecuteOrder(cartItems);
            }
        }
    }
}
