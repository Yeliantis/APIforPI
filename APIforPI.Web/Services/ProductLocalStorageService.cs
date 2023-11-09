using APIforPI.Infrastracture.Dto;
using APIforPI.Web.Services.Contracts;
using Blazored.LocalStorage;

namespace APIforPI.Web.Services
{
    public class ProductLocalStorageService : IProductLocalStorageService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IProductWebService _productWebService;
        private const string key = "Products";
        public ProductLocalStorageService(IProductWebService productWebService, ILocalStorageService localStorageService)
        {
            _productWebService = productWebService;
            _localStorageService = localStorageService;
        }
        public async Task RemoveCollection()
        {
            await _localStorageService.RemoveItemAsync(key);
        }

        public async Task<IEnumerable<ProductDto>> GetCollection()
        {
            var collection = await _localStorageService.GetItemAsync<IEnumerable<ProductDto>>(key);
            if (collection==null)
            {
               return await AddCollection();
            }
            return collection;
        }

        private async Task<IEnumerable<ProductDto>> AddCollection()
        {
            var productCollection = await _productWebService.GetItems();
            if (productCollection != null)
            {
                await _localStorageService.SetItemAsync(key, productCollection);
            }
            return productCollection;
        }
    }
}
