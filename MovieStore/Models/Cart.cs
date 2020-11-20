using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public Movie Movie { get; set; }
        public User CartOwner { get; set; }
        public bool IsRental { get; set; }
    }
}
