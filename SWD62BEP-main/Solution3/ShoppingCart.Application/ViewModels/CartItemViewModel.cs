using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual ProductViewModel Product { get; set; }

        public Guid Product_ID {get; set;}

        public int Cart_ID { get; set; }
    }
}
