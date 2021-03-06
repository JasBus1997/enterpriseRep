﻿using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartsRepository
    {
        Cart GetCurrentCart(string email);

        int AddingToCart(Cart cart);

        void DeleteFromCart(Cart cart);

        void UpdatingTheCart(Cart cart);
    }
}
