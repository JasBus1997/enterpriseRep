using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Application.ViewModels
{
    public class MemberViewModel
    {
        [Required(ErrorMessage = "Please input an email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please input a name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please input a surname")]
        public string LastName { get; set; }
    }
}
