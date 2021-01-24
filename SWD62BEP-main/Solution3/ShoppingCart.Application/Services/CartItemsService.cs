using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CartItemsService : ICartItemsService
    {
        private IMapper _mapper;
        private ICartItemsRepository _cartItemsRepo;
        private ICartsRepository _cartsRepo;
        public CartItemsService(ICartItemsRepository cartItemsRepository, ICartsRepository cartsRepository
        , IMapper mapper
        )
        {
            _mapper = mapper;
            _cartItemsRepo = cartItemsRepository;
            _cartsRepo = cartsRepository;
        }

        public void AddingToCartItem(CartItemViewModel c)
        {
            var item = _mapper.Map<CartItem>(c);
            _cartItemsRepo.AddingToCartItem(item);
        }

        public void DeleteFromCartItem(CartItemViewModel c)
        {
            var item = _cartItemsRepo.GetCurrentCartItem(c.Id);

            if (item != null)
            {
                _cartItemsRepo.DeleteFromCartItem(item);
            }
        }

        public CartViewModel GetCurrentCart(string email)
        {
            var cart = _cartsRepo.GetCurrentCart(email);
            var result = _mapper.Map<Cart, CartViewModel>(cart);
            return result;
        }

        public CartItemViewModel GetCurrentCartItem(int c)
        {
            var cart = _cartItemsRepo.GetCurrentCartItem(c);
            var result = _mapper.Map<CartItemViewModel>(cart);
            return result;
        }

        public void UpdatingTheCartItem(CartItemViewModel c)
        {
            var item = _cartItemsRepo.GetCurrentCartItem(c.Id);
            if (item != null)
            {
                item.Quantity = item.Quantity + 1;
                _cartItemsRepo.UpdatingTheCartItem(item);
            }
        }

        public IQueryable<CartItemViewModel> GetCurrentCartItem()
        {
            var items = _cartItemsRepo.GetCurrentCartItem().ProjectTo<CartItemViewModel>(_mapper.ConfigurationProvider);

            return items;
        }

        public CartItemViewModel GetAllCartProduct(int cart, Guid id)
        {
            var item = _cartItemsRepo.GetCurrentCartItem().Where(c => c.Cart_ID == cart && c.Product.Id == id).FirstOrDefault();

            var res = _mapper.Map<CartItem, CartItemViewModel>(item);
            return res;
        }
    }
}
