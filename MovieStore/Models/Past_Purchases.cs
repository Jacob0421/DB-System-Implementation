using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Past_Purchases
    {
        [Key]
        public Transaction Transaction{get; set;}
        [Key]
        public Customer Customer { get; set; }
        [Key]
        public Movie Movie { get; set; }
    }
}
