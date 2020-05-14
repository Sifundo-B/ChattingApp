﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Message"), Required]
        public string Text { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int CommentID { get; set; }
        [ForeignKey("CommentID")]
        public virtual Comment Comment { get; set; }
    }
} 
