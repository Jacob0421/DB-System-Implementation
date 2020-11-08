using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Movie
    {
        public int MovieNum { get; set; }
        public string MovieTitle { get; set; }
        public int DirectorNum { get; set; }
        public string MovieRating { get; set; }
        public string MovieReleaseDate{ get; set; }
        public string Genre { get; set; }
        public string AgeRating { get; set; }
    }
}
