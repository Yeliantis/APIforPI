using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
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
        [Inject]
        public IProductLocalStorageService _productLocalStorageService { get; set; }
        [Inject]
        public ICartItemsLocalStorageService _cartItemsLocalStorageService { get; set; }

        public CultureInfo culture { get; set; }
        public ProductDto Product { get; set; }
        public SushiDto SushiP { get; set; }
        public SetsDto SetsP { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            culture = new CultureInfo("ru-RU");
            var collection = await _productLocalStorageService.GetCollection();
            Product = collection.Where(x => x.Id == Id).FirstOrDefault();

            var cartItems = await _cartItemsLocalStorageService.GetCollection();
            var totalPrice = cartItems.Sum(x => x.TotalPrice).ToString("C", culture);

            _cartItemService.CallEventWhenCartChanged(totalPrice);
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
            var cartItems = await _cartItemService.GetItems(TemporaryUser.UserId);
            var totalPrice = cartItems.Sum(x => x.TotalPrice).ToString("C", culture);
            await _cartItemsLocalStorageService.SaveCollection(cartItems); //сохранение в локальное хранилище
            _cartItemService.CallEventWhenCartChanged(totalPrice);
        }
    }
}
