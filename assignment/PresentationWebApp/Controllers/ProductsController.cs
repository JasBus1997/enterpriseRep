using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;

namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productService)
        {
            _productsService = productService;
        }

        public IActionResult Index()
        {
            var list = _productsService.GetProducts();
            return View(list);
        }
    }
}
