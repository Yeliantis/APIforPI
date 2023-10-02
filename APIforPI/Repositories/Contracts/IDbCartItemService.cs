using APIforPI.Infrastracture.Dto;
using APIforPI.Infrastracture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Interfaces
{
    public interface IDbCartItemService
    {
        Task<CartItem> AddItem(CartItemAddDto cartItemToAdd);
        Task<CartItem> UpdateQty(int id, CartItemUpdateQtyDto cartItemToUpdate);
        
        Task<CartItem> DeleteItem(int id);
        Task<CartItem> GetItem(int id);
        Task<IEnumerable<CartItem>> GetCartItems(int Id);
        Task<CartItem> IncreaseQty(int id);
        Task<CartItem> DecreaseQty(int id);
    }
}
