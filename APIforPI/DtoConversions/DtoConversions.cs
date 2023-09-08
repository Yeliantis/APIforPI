using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;

namespace APIforPI.DtoConversions
{
    public static class DtoConversions
    {
        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems, IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.Id,
                        ProductName = product.Name,
                        ImageUrl = product.ImageURL,
                        Price = product.Price,
                        Qty = cartItem.Qty,
                        CartId = cartItem.CartId,
                        TotalPrice = product.Price * cartItem.Qty,

                    }).ToList();
        }
        public static CartItemDto ConvertToDto(this CartItem cartItem,  Product product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                ProductName = product.Name,
                ImageUrl = product.ImageURL,
                Price = product.Price,
                CartId = cartItem.CartId,
                Qty = cartItem.Qty,
                TotalPrice = product.Price * cartItem.Qty
            };
        }
    }
}
