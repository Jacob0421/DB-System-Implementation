using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class LoginModelView
    {
        public string UserUserName { get; }
        public string UserPassword { get; }
        public string ReturnUrl { get; set; } = "/";
    }
}
