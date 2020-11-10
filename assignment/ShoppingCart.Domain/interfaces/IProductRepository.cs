using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts(); //querable list / list of products - advantages; in it stores the commands
        Product GetProduct(Guid id);

        void DeleteProduct(Product p);

        Guid AddProduct(Product p);
    }
}
