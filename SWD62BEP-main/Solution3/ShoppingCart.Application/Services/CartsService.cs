using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CartsService : ICartsService
    {
        private IMapper _mapper;
        private ICartsRepository _cartRepo;
        public CartsService(ICartsRepository cartsRepository
        , IMapper mapper
        )
        {
            _mapper = mapper;
            _cartRepo = cartsRepository;
        }

        public int AddingToCart(CartViewModel c)
        {
            Cart cart = new Cart()
            {
                Id = c.id,
                Email = c.Email,
                price = c.Price
            };

            _cartRepo.AddingToCart(cart);
            return cart.Id;
        }

        public void DeleteFromCart(CartViewModel c)
        {
            Cart cart = _cartRepo.GetCurrentCart(c.Email);
            if (cart != null)
            {
                _cartRepo.DeleteFromCart(cart);
            }
        }

        public CartViewModel GetCurrentCart(string email)
        {
            Cart cart = _cartRepo.GetCurrentCart(email);
            var res = _mapper.Map<Cart, CartViewModel>(cart);
            return res;
        }

        public void UpdatingTheCart(CartViewModel c)
        {
            Cart cart = _cartRepo.GetCurrentCart(c.Email);
            double amount = 0;
            foreach (var crt in cart.CartItems)
            {
                amount = amount + crt.Product.Price + crt.Quantity;
            }
            cart.price = amount;
            _cartRepo.UpdatingTheCart(cart);

            var res = _mapper.Map<Cart, CartViewModel>(cart);
        }
    }
}
