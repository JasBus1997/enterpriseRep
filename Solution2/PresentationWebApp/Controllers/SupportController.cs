using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWebApp.Controllers
{
    public class SupportController : Controller
    {
        [HttpGet] // get methods 
        public IActionResult Contact() // this to load the page
        {
            return View();
        }


        [HttpPost] // when submitting a form ( pressing the submit button )
        public IActionResult Contact(string email, string query) //the name in the form
        {
            if (string.IsNullOrEmpty(query))
                ViewData["warning"] = "type in some question";
            else
                ViewData["feedback"] = "thank you for getting in touch with us.";

            return View();
        }
    }
}
