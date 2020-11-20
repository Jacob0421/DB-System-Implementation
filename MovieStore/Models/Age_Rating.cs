using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Age_Rating
    {
        [Key]
        public string AgeRating { get; set; }
    }
}
