using Chat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult UserProfile()
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            //if user is logged in.
            return View(db.Users.Find(userId));
        }
        //Post: User/UpdatePicture
        [HttpPost]
        public ActionResult UpdatePicture(PictureVM obj)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            //if user is logged in
            var file = obj.Picture;

            User u = db.Users.Find(userId);
            if (file!=null)
            {
                //Update the image
                var extension = Path.GetExtension(file.FileName);
                string id_and_extension = userId + extension;
                string imgUrl = "~/Profile Images/" + id_and_extension;
                u.ImageUrl = imgUrl;
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();

                var path = Server.MapPath("~/Profile Images/");
                if (!Directory.Exists(path)) 
                {
                    Directory.CreateDirectory(path);
                }
                if ((System.IO.File.Exists(path+id_and_extension)))
                {
                    System.IO.File.Delete(path + id_and_extension);
                }
                file.SaveAs((path + id_and_extension));
            }
            return RedirectToAction("UserProfile");
        }
    }
}