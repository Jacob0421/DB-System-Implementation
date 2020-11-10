using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Customer
    {
        [Key]
        public int CustomerNum { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerDOB { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public double AmountOwed { get; set; }
        public double AmountPaid { get; set; }
        public int RecommendedBy { get; set; }
    }
}
