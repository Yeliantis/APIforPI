using APIforPI.Infrastracture.Dto;
using APIforPI.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;

namespace APIforPI.Web.Pages
{
    public class CartDisplayBase : ComponentBase
    {
        [Inject]
        public ICartItemWebService CartItemWebService { get; set; }
        public IEnumerable<CartItemDto> CartItems { get; set; }
        
        public CultureInfo culture { get; set; }
        protected override async Task OnInitializedAsync()
        {
            CartItems = await CartItemWebService.GetItems(TemporaryUser.UserId);
            culture = new CultureInfo("ru-RU");
        }
        protected async Task DeleteFromCart_Click(int id)
        {
            var cartItemDtoToDelete = await CartItemWebService.DeleteItem(id);
            //CartItems = await CartItemWebService.GetItems(TemporaryUser.UserId);
            var list = CartItems.ToList();
            list.Remove(list.Where(x=> x.Id==cartItemDtoToDelete.Id).FirstOrDefault());
            CartItems= list;
        }

        
        
    }
}
