﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text),Required]
        public string Text { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<Reply>Replies{get;set;}
    }
}