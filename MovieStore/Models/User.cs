using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class User
    {
        [Key]
        [Display(Name ="Id")]
        public int UserNum { get; set; }
        [Display(Name = "Username")]
        public string UserUserName { get; set; }
        public string UserPassword { get; set; }
        public string UserDOB { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public decimal AmountOwed { get; set; }
        public decimal AmountPaid { get; set; }
        public int RecommendedBy { get; set; }
        public string role { get; set; }
        public decimal UserCartTotal { get; set; }
    }
}
