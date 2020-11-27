using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IMovieRepository
    {
        Movie Add(Movie movieIn);
        Movie Update(Movie movieChanges);
        Movie Delete(int id);
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovie(int id);
        IEnumerable<Movie> SearchMovies(string movieIn);
        Genre GetMovieGenre(Movie movieIn);
        Movie GetMovieByName(string nameIn);
    }
}
