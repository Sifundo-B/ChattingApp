using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Chat.ViewModels;

namespace Chat.Controllers
{
    public class ChatRoomController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ChatRoom
        public ActionResult Index()
        {
            //To display comments with replies.
            var comments = db.Comments.Include(x => x.Replies)
                .OrderByDescending(c=>c.CreatedOn).ToList();

            return View(comments);
        }
        //Post: ChatRoom/PostReply
        [HttpPost]
        public ActionResult PostReply(ReplyVM obj)
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            //check if user is logged in 
            if (userid == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            Reply r = new Reply();
            r.Text = obj.Reply;
            r.CommentID = obj.CID;
            r.UserId = userid;
            r.CreatedOn = DateTime.Now;
            db.Replies.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Post: ChatRoom/PostComment
        [HttpPost]
        public ActionResult PostComment(string Coment)
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            //check if user is logged in 
            if (userid == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            Comment c = new Comment();
            c.Text = Coment;
            c.CreatedOn = DateTime.Now;
            c.UserId = userid;

            db.Comments.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}