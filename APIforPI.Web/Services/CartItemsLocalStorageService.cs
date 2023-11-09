using APIforPI.Infrastracture.Dto;
using APIforPI.Web.Services.Contracts;
using Blazored.LocalStorage;

namespace APIforPI.Web.Services
{
    public class CartItemsLocalStorageService : ICartItemsLocalStorageService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly ICartItemWebService _cartItemWebService;

        const string key = "CartItems";
        public CartItemsLocalStorageService(ICartItemWebService cartItemWebService, ILocalStorageService localStorageService)
        {
            _cartItemWebService = cartItemWebService;
            _localStorageService = localStorageService;
        }
        public async Task<IEnumerable<CartItemDto>> GetCollection()
        {
            var collection = await _localStorageService.GetItemAsync<IEnumerable<CartItemDto>>(key);
            if (collection==null)
            {
                return await AddCollection();
            }
            return collection;
        }

        public async Task RemoveCollection()
        {
            await _localStorageService.RemoveItemAsync(key);
        }

        public async Task SaveCollection(IEnumerable<CartItemDto> cartItems)
        {
            await _localStorageService.SetItemAsync(key, cartItems);
        }

        private async Task<IEnumerable<CartItemDto>> AddCollection()
        {
            var cartItems = await _cartItemWebService.GetItems(1);
            if (cartItems !=null)
            {
                await _localStorageService.SetItemAsync(key, cartItems);
            }
            return cartItems;
        }
    }
}
