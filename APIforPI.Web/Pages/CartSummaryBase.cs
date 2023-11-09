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
        public ICartItemsLocalStorageService _cartItemsLocalStorageService { get; set;}
        [Inject]
        public IOrderWebService _orderService { get; set; }
        public IEnumerable<CartItemDto> cartItems { get; set; }
        [Inject]
        public NavigationManager NavigationManager {get;set;}
        public bool IsOrderCreated { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            var items = await _cartItemsLocalStorageService.GetCollection();
            if (items != null && items.Count()>0)
            {
                cartItems = items;
            }
            else
            {
                cartItems = null;
            }
        }

        protected async Task MakeOrder_Click(IEnumerable<CartItemDto> cartItems)
        {
            if (cartItems.Count() >0)
            {
                var result = await _orderService.ExecuteOrder(cartItems);
               await _cartItemWebService.ClearCartAsync(1);
               await _cartItemsLocalStorageService.RemoveCollection();
                IsOrderCreated= true;
               
            }
        }

        protected void NavigateToMainPage_Click()
        {
            
            NavigationManager.NavigateTo("/");
        }

       
    }
}
