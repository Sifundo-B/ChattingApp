using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(3)]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(6),Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [MinLength(6), Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Picture")]
        public string ImageUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}