using APIforPI.Infrastracture.Dto;
using APIforPI.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace APIforPI.Web.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductWebService _productService { get; set; }
        public IEnumerable<ProductDto> Products { get; set;}
        public CultureInfo culture { get; set; }
        

        protected override async Task OnInitializedAsync()
        {
            culture = new CultureInfo("ru-RU");
            Products = await _productService.GetItems();
        }
    }
}
