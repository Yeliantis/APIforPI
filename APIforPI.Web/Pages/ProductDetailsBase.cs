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
        public CultureInfo culture { get; set; }
        public ProductDto Product { get; set; }
        public SushiDto SushiP { get; set; }
        public SetsDto SetsP { get; set; }
        protected override async Task OnInitializedAsync()
        {
            culture = new CultureInfo("ru-RU");
            var result = await _productService.GetItem(Id);
            if (result.Category == "Sushi")
            {
                SushiP = await _productService.GetSushi(Id);
            }
           
            else
            {
                SetsP = await _productService.GetSet(Id);
            }
        }
    }
}
