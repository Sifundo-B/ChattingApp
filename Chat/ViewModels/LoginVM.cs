using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.ViewModels
{
    public class LoginVM
    {
        [Required, MinLength(5)]
        public string Username { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password"), DataType(DataType.Password), Required]
        public string Password { get; set; }
    }
}