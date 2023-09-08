using APIforPI.Infrastracture.Dto;
using APIforPI.Models;
using APIforPI.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client;
using System.Globalization;

namespace APIforPI.Web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductWebService _productService { get; set; }
        [Inject]
        public ICartItemWebService _cartItemService { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        public CultureInfo culture { get; set; }
        public ProductDto Product { get; set; }
        public SushiDto SushiP { get; set; }
        public SetsDto SetsP { get; set; }
        protected override async Task OnInitializedAsync()
        {
            culture = new CultureInfo("ru-RU");
            Product = await _productService.GetItem(Id);
            
            if (Product.Category == "Sushi")
            {
                SushiP = await _productService.GetSushi(Id);
            }
           
            else
            {
                SetsP = await _productService.GetSet(Id);
            }
        }

        protected async Task AddToCart_Click(CartItemAddDto cartItemAddDto)
        {
            var cartItemDto = await _cartItemService.AddItem(cartItemAddDto);
            Navigation.NavigateTo("/Cart");
        }
    }
}
