using Chat.Models;
using Chat.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
namespace Chat.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM obj)
        {
            bool UserExists = db.Users.Any(x => x.UserName == obj.UserName);
            //checks If username is already in use
            if (UserExists)
            {
                ViewBag.UsernameMessage = "This username is already in user, try another";
                return View();
            }
            bool EmailExists = db.Users.Any(y => y.Email == obj.Email);
            //Checks if email is in user
            if (EmailExists)
            {
                ViewBag.EmailMessage = "This Email is already registered";
                return View();
            }
            //If username and email is unique, then we save or register the user
            User u = new User();
            u.UserName = obj.UserName;
            u.Password = obj.Password;
            u.ConfirmPassword = obj.ConfirmPassword;
            u.Email = obj.Email;
            u.ImageUrl = null;
            u.CreatedOn = DateTime.Now;
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index","ChatRoom");  
        }
        //GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM obj)
        {
            bool exists = db.Users.Any(u => u.UserName == obj.Username && u.Password == obj.Password);
            //checks if the inserted username and password does exists in the database
            if (exists)
            {
                Session["UserID"] = db.Users.Single(x => x.UserName == obj.Username).Id;
                return RedirectToAction("Index", "ChatRoom");
            }
            //If credentials are not valid
            ViewBag.Message = "Username or Password incorrect!";  
            return View();
        } 
    }
}