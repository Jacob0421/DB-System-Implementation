using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieStore.Models;

namespace MovieStore.ViewModels
{
    public class MovieViewModel
    {
        public Movie MovieIn { get; set; }
        public string GenreName { get; set; }
        public string DirectorName { get; set; }
        public string Age_Rating { get; set; }
    }
}
