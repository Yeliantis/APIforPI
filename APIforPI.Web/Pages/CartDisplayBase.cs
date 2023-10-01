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
        public ICartItemWebService _cartItemWebService { get; set; }
        public IEnumerable<CartItemDto> CartItems { get; set; }
        
        public CultureInfo culture { get; set; }
        protected override async Task OnInitializedAsync()
        {
            CartItems = await _cartItemWebService.GetItems(TemporaryUser.UserId);
            culture = new CultureInfo("ru-RU");
        }
        protected async Task DeleteFromCart_Click(int id)
        {
            var cartItemDtoToDelete = await _cartItemWebService.DeleteItem(id);
            //CartItems = await CartItemWebService.GetItems(TemporaryUser.UserId);
            var list = CartItems.ToList();
            list.Remove(list.Where(x=> x.Id==cartItemDtoToDelete.Id).FirstOrDefault());
            CartItems= list;
        }

        protected async Task UpdateCartItemQty_Click(int id, int qty)
        {
            if (qty>0)
            {
                var updateItemDto = new CartItemUpdateQtyDto
                {
                    CartItemId = id,
                    Qty = qty
                };
                var returnedItem = await _cartItemWebService.UpdateQty (updateItemDto);
            }
            else
            {
                var item = CartItems.FirstOrDefault(x => x.Id == id);
                if (item!=null)
                {
                    item.Qty = 1;
                    item.TotalPrice = item.Price * item.Qty;
                }
            }
        }
        
        
    }
}
