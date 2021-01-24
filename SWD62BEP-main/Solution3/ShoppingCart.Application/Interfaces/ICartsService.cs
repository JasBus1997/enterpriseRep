using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartsService
    {
        CartViewModel GetCurrentCart(string email);

        int AddingToCart(CartViewModel cart);

        void DeleteFromCart(CartViewModel cart);

        void UpdatingTheCart(CartViewModel cart);
    }
}
