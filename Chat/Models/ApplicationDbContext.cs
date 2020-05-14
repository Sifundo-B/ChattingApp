using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("ChatDb")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}