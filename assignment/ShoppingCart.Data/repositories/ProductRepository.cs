using ShoppingCart.Data.Context;
using ShoppingCart.Domain.interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.repositories
{
    public class ProductRepository : IProductRepository
    {
        ShoppingCartDbContext _context;

        public ProductRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public Guid AddProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges(); //saves changes in memory even after you switch off your server/pc
            return p.Id;
        }

        public void DeleteProduct(Product p)
        {
            _context.Products.Remove(p);
            _context.SaveChanges();
        }

        public Product GetProduct(Guid id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id); // single or default will return 1 product or NULL
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }
    }
}
