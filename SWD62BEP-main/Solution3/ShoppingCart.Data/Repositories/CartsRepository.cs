using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Data.Repositories
{
    public class CartsRepository: ICartsRepository
    {
        ShoppingCartDbContext _context;
        public CartsRepository(ShoppingCartDbContext context)
        {
            _context = context;

        }

        public int AddingToCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return cart.Id;
        }

        public void DeleteFromCart(Cart cart)
        {
            _context.Carts.Remove(cart);
            _context.SaveChanges();
        }

        public Cart GetCurrentCart(string email)
        {
            return _context.Carts.Include(x => x.CartItems).SingleOrDefault(x => x.Email == email);
        }

        public void UpdatingTheCart(Cart cart)
        {
            _context.Entry(cart);
            _context.SaveChanges();
        }
    }
}
