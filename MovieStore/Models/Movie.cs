using Microsoft.AspNetCore.Mvc;
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
        public Director Director{ get; set; }
        [HiddenInput]
        public int MovieRating { get; set; }
        public string MovieReleaseDate{ get; set; }
        public Genre Genre { get; set; }
        public Age_Rating AgeRating { get; set; }
        public decimal RentalPrice { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
