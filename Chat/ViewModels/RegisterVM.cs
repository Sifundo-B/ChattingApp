using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.ViewModels
{
    public class RegisterVM
    {
        [Required,MinLength(3)]      
        public string UserName { get; set; }
        [MinLength(6),Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password"),DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
        [EmailAddress,Required]
        public string Email { get; set; }
    }
}