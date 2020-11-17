using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionNum { get; set; }
        public string TransactionDate { get; set; }
        public User Customer { get; set; }
        public Movie Movie { get; set; }
        public bool IsRental { get; set; }
    }
}
