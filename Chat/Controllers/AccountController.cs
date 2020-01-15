using Chat.Models;
using Chat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Controllers
{
    public class AccountController : Controller
    {
        private ChatContext db = new ChatContext();
        // GET: Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        // GET: Account/Register
        [HttpPost]
        public ActionResult Register(RegisterVM objReg)
        {
            bool UserExists = db.Users.Any(x => x.Username == objReg.Username);
            if(UserExists) //if username is already in use
            {
                ViewBag.UsernameMessage = "This username is already in use, try another one";
                return View();
            }
            bool EmailExits = db.Users.Any(c => c.Email == objReg.Email);
            if (EmailExits)
            {
                ViewBag.EmailMessage = "This email is already registered";
                return View();
            }
            //if username and email address is unique, then we save or register the user
            User sebenza = new User();
            sebenza.Username = objReg.Username;
            sebenza.Password = objReg.Password;
            sebenza.ConfirmPassword = objReg.ConfirmPassword;
            sebenza.Email = objReg.Email;
            sebenza.ImageUrl = null;
            sebenza.CreatedOn = DateTime.Now;

            db.Users.Add(sebenza);
            db.SaveChanges();
            return RedirectToAction("Index","ChatRoom");
        }
        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // GET: Account/Login
        [HttpPost]
        public ActionResult Login(LoginVM objlog)
        {
            bool exists = db.Users.Any(x => x.Username == objlog.Username && x.Password == objlog.Password);

            if (exists)
            {
                return RedirectToAction("Index", "ChatRoom");

            }
            // if invalid credentials
            ViewBag.Message = "Please enter valid credentials";
            return View();
        }
    }

}