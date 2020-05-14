﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}