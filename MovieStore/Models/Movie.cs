using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Movie
    {
        [Key]
        public int MovieNum { get; set; }

        public string MovieTitle { get; set; }
        public int DirectorNum { get; set; }
        public string MovieRating { get; set; }
        public string MovieReleaseDate{ get; set; }
        public string Genre { get; set; }
        public string AgeRating { get; set; }
    }
}
