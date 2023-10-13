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
        public IEnumerable<ProductDto> Products { get; set;}
        public CultureInfo culture { get; set; }
        

        protected override async Task OnInitializedAsync()
        {
            culture = new CultureInfo("ru-RU");
            
            Products = await _productService.GetItems();

            var cartItems = await _cartService.GetItems(TemporaryUser.UserId);
            var totalPrice = cartItems.Sum(x => x.TotalPrice).ToString("C", culture);

            _cartService.CallEventWhenCartChanged(totalPrice);

        }
    }
}
