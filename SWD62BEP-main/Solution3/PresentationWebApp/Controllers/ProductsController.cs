using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using X.PagedList;



namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;
        private string sessionKey = "ShoppingCart";



        public ProductsController(IProductsService productsService, ICategoriesService categoriesService,
             IWebHostEnvironment env)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
        }



        public IActionResult Index(int page = 1)
        {
            //Getting category from db and passing them to Viewbag
            var listOfCategeories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategeories;



            var list = _productsService.GetProducts();
            ViewBag.PageList = GetPagedNames(page, list);
            ViewBag.SearchPage = false;



            return View(GetPagedNames(page, list));
        }



        [HttpPost]
        public IActionResult Search(string keyword) //using a form, and the select list must have name attribute = category
        {
            var list = _productsService.GetProducts(keyword).ToList();



            return View("Index", list);
        }




        public IActionResult Details(Guid id)
        {
            var p = _productsService.GetProduct(id);
            return View(p);
        }



        //the engine will load a page with empty fields
        [HttpGet]
        [Authorize(Roles = "Admin")] //is going to be accessed only by authenticated users
        public IActionResult Create()
        {
            //fetch a list of categories
            var listOfCategeories = _categoriesService.GetCategories();



            //we pass the categories to the page
            ViewBag.Categories = listOfCategeories;



            return View();
        }



        //here details input by the user will be received
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel data, IFormFile f)
        {
            try
            {
                if (f != null)
                {
                    if (f.Length > 0)
                    {
                        //C:\Users\Ryan\source\repos\SWD62BEP\SWD62BEP\Solution3\PresentationWebApp\wwwroot
                        string newFilename = Guid.NewGuid() + System.IO.Path.GetExtension(f.FileName);
                        string newFilenameWithAbsolutePath = _env.WebRootPath + @"\Images\" + newFilename;

                        using (var stream = System.IO.File.Create(newFilenameWithAbsolutePath))
                        {
                            f.CopyTo(stream);
                        }



                        data.ImageUrl = @"\Images\" + newFilename;
                    }
                }



                _productsService.AddProduct(data);



                TempData["feedback"] = "Product was added successfully";
            }
            catch (Exception ex)
            {
                //log error
                TempData["warning"] = "Product was not added! - " + ex.Message;
            }



            var listOfCategeories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategeories;
            return View(data);

        } //fiddler, burp, zap, postman



        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productsService.DeleteProduct(id);
                TempData["feedback"] = "Product was deleted";
            }
            catch (Exception ex)
            {
                //log your error 



                TempData["warning"] = "Product was not deleted - " + ex.Message; //Change from ViewData to TempData
            }



            return RedirectToAction("Index");
        }



        public IActionResult Hide(Guid id)
        {
            try
            {
                //Methoud call from the Iproductservice class
                _productsService.HideProduct(id);
                TempData["feedback"] = "Show/Hide button was pressed";
            }
            catch (Exception ex)
            {
                //Catch error when trying to perform Hide/show button
                TempData["warning"] = "Show/Hide button was pressed but not successful - " + ex.Message;
            }



            return RedirectToAction("Index");
        }



        protected IPagedList<ProductViewModel> GetPagedNames(int? page, IQueryable<ProductViewModel> productList)
        {
            // return a 404 if user browses to before the first page
            if (page.HasValue && page < 1)
                return null;



            // retrieve list from database/wherever
            var listUnpaged = productList;



            // page the list
            const int pageSize = 10;
            var listPaged = listUnpaged.ToPagedList(page ?? 1, pageSize);



            // return a 404 if user browses to pages beyond last page. special case first page if no items exist
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;



            return listPaged;
        }



        public IActionResult CatSearch(int catId, int page = 1)
        {
            //Retrives all categories from db
            var Categeories = _categoriesService.GetCategories();
            ViewBag.Categories = Categeories;



            //Gets all products with specified category 
            var list = _productsService.GetProducts(catId);
            ViewBag.PageList = GetPagedNames(page, list);

            //Pagination handler for active page
            ViewBag.SearchPage = true;



            return View("Index", list);
        }
        /*
        public IActionResult CartAddition(int id) 
        {
            //Retrives shopping cart content from current user session
            var cStr = HttpContext.Session.GetString(sessionKey);

 

            if (string.IsNullOrEmpty(cStr))
            {
                string guidString = id.ToString();
                HttpContext.Session.SetString(sessionKey, guidString);
            }
            else
            {
                string guidString = id.ToString();
                cStr = cStr + "," + guidString;
                HttpContext.Session.SetString(sessionKey, cStr);
            }

 

            cStr = HttpContext.Session.GetString(sessionKey);

 

            var list = _productsService.GetCart(cStr);

 

            return View("Cart", list);
            
        }
            */



    }
}