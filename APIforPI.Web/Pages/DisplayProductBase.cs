using APIforPI.Infrastracture.Dto;
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
        [Parameter]
        public CultureInfo culture { get; set; }
        [Inject]
        public ICartItemWebService CartItemWebService { get; set; }

        protected async Task AddToCart_Click(CartItemAddDto cartItemAddDto)
        {
            var cartItemDto = await CartItemWebService.AddItem(cartItemAddDto);   
        }
    }
}
