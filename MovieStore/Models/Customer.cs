using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Customer
    {
        public int CustomerNum { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerDOB { get; set; }
        public int CustomerFirstName { get; set; }
        public int CustomerLastName { get; set; }
        public int AmountOwed { get; set; }
        public int AmountPaid { get; set; }
        public Customer RecommendedBy { get; set; }
    }
}
