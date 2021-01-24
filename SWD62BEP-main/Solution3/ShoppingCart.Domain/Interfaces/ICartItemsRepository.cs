using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartItemsRepository
    {
        CartItem GetCurrentCartItem(int id);

        IQueryable<CartItem> GetCurrentCartItem();

        void  AddingToCartItem(CartItem CartItem);

        void DeleteFromCartItem(CartItem CartItem);

        void UpdatingTheCartItem(CartItem CartItem);
    }
}
