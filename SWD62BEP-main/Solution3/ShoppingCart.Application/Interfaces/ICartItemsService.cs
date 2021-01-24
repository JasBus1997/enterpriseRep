using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartItemsService
    {
        IQueryable <CartItemViewModel> GetCurrentCartItem();

        CartItemViewModel GetCurrentCartItem(int id);

        CartViewModel GetCurrentCart(string email);

        CartItemViewModel GetAllCartProduct(int cart, Guid id); //get cart with everything

        void AddingToCartItem(CartItemViewModel cartItem);

        void DeleteFromCartItem(CartItemViewModel cartItem);

        void UpdatingTheCartItem(CartItemViewModel cartItem);
    }
}
