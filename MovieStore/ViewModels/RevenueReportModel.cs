using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.ViewModels
{
    public class RevenueReportModel
    {
        public List<MovieList> MovieList { get; set; }
        public List<GenreList> GenreList { get; set; }
        public string TotalRevenue { get; set; }
        public string TotalLateFees { get; set; }
    }
    public class MovieList
    {
        public int movieId { get; set; }
        public string movieTitle { get; set; }
    }

    public class GenreList
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
