using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Review
    {
        [Key]
        public int ReviewNum { get; set; }
        [Key]
        public Movie Movie{ get; set; }
        public string ReviewTitle { get; set; }
        public string MovieTitle { get; set; }
        public User Author { get; set; }
        public string ReviewBody { get; set; }
        public string ReviewDate { get; set; }
        public int StarRating { get; set; }
    }
}
