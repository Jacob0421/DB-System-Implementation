using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class MovieRepository : IMovieRepository
    {

        private readonly AppDbContext _context;

        public MovieRepository (AppDbContext context)
        {
            _context = context;
        }

        public Movie Add(Movie movieIn)
        {
            if (movieIn != null)
            _context.Add(movieIn);
            _context.SaveChanges();
            return movieIn;
        }

        public Movie Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.Include(m => m.Director).Include(m => m.Genre).Include(m => m.AgeRating).AsEnumerable();

        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.MovieNum == id);
        }

        public Movie Update(Movie movieChanges)
        {
            throw new NotImplementedException();
        }
    }
}
