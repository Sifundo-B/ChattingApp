using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="User Name"), MinLength(3),Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password"), DataType(DataType.Password), Required]
        public string Password { get; set; }
        [Display(Name = "Confirm password"),DataType(DataType.Password),Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name ="Email"),DataType(DataType.EmailAddress),Required]
        public string Email { get; set; }
        [Display(Name ="Upload Image"),DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Display(Name ="Date Created")]
        public DateTime? CreatedOn { get; set; }
    }
}