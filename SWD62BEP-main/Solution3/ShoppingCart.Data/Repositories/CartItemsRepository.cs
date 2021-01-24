using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CartItemsRepository : ICartItemsRepository
    {
        ShoppingCartDbContext _context;
        public CartItem GetCurrentCartItem(int id)
        {
            return _context.CartItems.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<CartItem> GetCurrentCartItem()
        {
            return _context.CartItems;
        }

        public void AddingToCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }

        public void DeleteFromCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }

        public void UpdatingTheCartItem(CartItem cartItem)
        {
            var curr = _context.CartItems.SingleOrDefault(x => x.Id == cartItem.Id);

            if (curr != null)
            {
                curr.Quantity = cartItem.Quantity;

                _context.Entry(curr);
                _context.SaveChanges();
            }
        }

    }
}
