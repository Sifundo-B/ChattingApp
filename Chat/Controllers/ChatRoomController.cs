using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Chat.Controllers
{
    public class ChatRoomController : Controller
    {
        private ChatContext db = new ChatContext();
        // GET: ChatRoom
        public ActionResult Index()
        {
            var comments = db.Comments.Include(x => x.Replies).ToList();
            return View(comments);
        }
    }
}