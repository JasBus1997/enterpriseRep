using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.interfaces
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> GetCategories();
    }
}
