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

        public IActionResult Details(Guid id)
        {
            var p = _productsService.GetProduct(id);
            return View(p);
        }
        [HttpGet] // the engine will load a page with empty fields
        public IActionResult Create()
        {
            //fetch list of categories
            //pass the categories to the page
            return View();
        }

       /* [HttpPost] // details input by the user will be received
        public IActionResult Create()
        {

        }*/
    }
}
