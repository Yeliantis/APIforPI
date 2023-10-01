using APIforPI.Data;
using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Interfaces;
using APIforPI.Infrastracture.Models;
using Microsoft.EntityFrameworkCore;

namespace APIforPI.DbServices
{
    public class CartItemRepository : IDbCartItemService
    {
        private readonly DataContext _dataContext;
        public CartItemRepository(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        private async Task<bool> ItemExists(int cartId, int productId)
        {
            var check = await _dataContext.CartItems.AnyAsync(x=>x.CartId == cartId && x.ProductId==productId);
            return check;
        }
        public async Task<CartItem> AddItem(CartItemAddDto cartItemToAdd)
        {
            if (await ItemExists(cartItemToAdd.CartId, cartItemToAdd.ProductId) == false)
            {
                var item = await _dataContext.Products.Where(x => x.Id == cartItemToAdd.ProductId).Select(o => new CartItem
                {
                    CartId = cartItemToAdd.CartId,
                    ProductId = cartItemToAdd.ProductId,
                    Qty = cartItemToAdd.Qty
                }).FirstOrDefaultAsync();
                if (item != null)
                {
                    var result = await _dataContext.CartItems.AddAsync(item);
                    await _dataContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
                
            
            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
           var item = await _dataContext.CartItems.Where(x=>x.Id== id).FirstOrDefaultAsync();
            if (item != null)
            {
                _dataContext.CartItems.Remove(item);
               await _dataContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(int Id)
        {
            return await (from cart in _dataContext.Carts
                          join CartItem in _dataContext.CartItems
                          on cart.Id equals CartItem.CartId
                          where cart.UserId == Id
                          select new CartItem
                          {
                              Id = CartItem.Id,
                              CartId = CartItem.Id,
                              ProductId = CartItem.ProductId,
                              Qty = CartItem.Qty
                          }).ToListAsync();
        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in _dataContext.Carts
                          join CartItem in _dataContext.CartItems
                          on cart.Id equals CartItem.CartId
                          where CartItem.Id == id
                          select new CartItem
                          {
                              Id = CartItem.Id,
                              CartId = CartItem.Id,
                              ProductId = CartItem.ProductId,
                              Qty = CartItem.Qty
                          }).SingleOrDefaultAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemUpdateQtyDto cartItemToUpdate)
        {
            var item = await _dataContext.CartItems.FindAsync(id);
            if (item!=null)
            {
                item.Qty = cartItemToUpdate.Qty;
                await _dataContext.SaveChangesAsync();
                return item;
            }
            return null;
        }
    }
}
