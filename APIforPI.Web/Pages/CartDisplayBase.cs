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
        protected string TotalPrice { get; set; }
        
        protected int TotalQty { get; set; }
        public CultureInfo culture { get; set; }
        protected override async Task OnInitializedAsync()
        {
            CartItems = await _cartItemWebService.GetItems(TemporaryUser.UserId);
            culture = new CultureInfo("ru-RU");
            CartChanged();
        }
        protected async Task DeleteFromCart_Click(int id)
        {
            var cartItemDtoToDelete = await _cartItemWebService.DeleteItem(id);
            CartItems = CartItems.Where(x => x.Id != id).ToList();
            CartChanged();
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
                UpdateItemTotalPrice(returnedItem);
                CartChanged();

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
        protected async Task IncreaseCartItemQty_Click(int id)
        {
            var returnedItem = await _cartItemWebService.IncreaseQty(id);
            CartItems.Where(x => x.Id == id).FirstOrDefault().Qty++;
            UpdateItemTotalPrice(returnedItem);
            CartChanged();
        }
        protected async Task DecreaseCartItemQty_Click(int id)
        {
            var returnedItem = await _cartItemWebService.DecreaseQty(id);
            CartItems.Where(x => x.Id == id).FirstOrDefault().Qty--;
            UpdateItemTotalPrice(returnedItem);
            CartChanged();

        }
        private CartItemDto GetCartItem(int id)
        {
            return CartItems.Where(x => x.Id == id).FirstOrDefault();
        }

        private void CountTotalPrice()
        {
            TotalPrice = this.CartItems.Sum(x => x.TotalPrice).ToString("C",culture);
        }
        private void UpdateItemTotalPrice(CartItemDto cartItemDto)
        {
            var item = GetCartItem(cartItemDto.Id);
            if (item!=null)
            {
                item.TotalPrice = item.Price * item.Qty;
            }

        }

        private void CartChanged()
        {
            CountTotalPrice();

            _cartItemWebService.CallEventWhenCartChanged(TotalPrice);
        }
        public async Task ClearCart_Click(int cartId)
        {
            var result = await _cartItemWebService.ClearCartAsync(cartId);

           CartItems = await _cartItemWebService.GetItems(TemporaryUser.UserId);
           StateHasChanged();
           CartChanged();
           
        }
        
    }
}
