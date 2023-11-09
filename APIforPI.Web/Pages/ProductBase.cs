using APIforPI.Infrastracture.Dto;
using APIforPI.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace APIforPI.Web.Pages
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        public IProductWebService _productService { get; set; }
        [Inject]
        public ICartItemWebService _cartService { get; set; }
        [Inject]
        public IProductLocalStorageService _productLocalStorageService { get; set; }
        [Inject]
        public ICartItemsLocalStorageService _cartItemsLocalStorageService { get; set; }
        public IEnumerable<ProductDto> Products { get; set;}
        public CultureInfo culture { get; set; }
        

        protected override async Task OnInitializedAsync()
        {
            culture = new CultureInfo("ru-RU");
            ClearLocalStorage();
           
            Products = await _productLocalStorageService.GetCollection();

            var cartItems = await _cartItemsLocalStorageService.GetCollection();
            var totalPrice = cartItems.Sum(x => x.TotalPrice).ToString("C", culture);

            _cartService.CallEventWhenCartChanged(totalPrice);

        }

        private async Task ClearLocalStorage()
        {
            await _cartItemsLocalStorageService.RemoveCollection();
            await _productLocalStorageService.RemoveCollection();
        }
    }
}
