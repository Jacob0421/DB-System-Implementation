using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class LoginModelView
    {
        public string UserUserName { get; set; }
        public string UserPassword { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
