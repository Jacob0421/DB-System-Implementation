﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class MovieRepository : IMovieRepository
    {

        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public Movie Add(Movie movieIn)
        {
            if (movieIn != null)
            {
                DateTime releaseDate = DateTime.Parse(movieIn.MovieReleaseDate);

                if (releaseDate.AddMonths(2) >= DateTime.Today)
                    movieIn.IsNewRelease = true;
                else
                    movieIn.IsNewRelease = false;

                if (movieIn.IsNewRelease)
                {
                    movieIn.RentalPrice = (decimal)4.50;
                    movieIn.PurchasePrice = (decimal)30.00;
                }
                else
                {
                    movieIn.RentalPrice = (decimal)3.00;
                    movieIn.PurchasePrice = (decimal)20.00;
                }
                _context.Add(movieIn);
                _context.SaveChanges();
            }
            return movieIn;
        }

        public Movie Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.Include(m => m.Director).Include(m => m.Genre).Include(m => m.AgeRating).AsEnumerable().OrderBy(m => m.MovieTitle);

        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.MovieNum == id);
        }

        public Movie GetMovieByName(string nameIn)
        {
            return _context.Movies.FirstOrDefault(m => m.MovieTitle == nameIn);
        }

        public Genre GetMovieGenre(Movie movieIn)
        {
            return movieIn.Genre;
        }

        public IEnumerable<Movie> SearchMovies(string keyIn)
        {
            IEnumerable<Movie> searchResults = _context.Movies.Include(m => m.Director).Include(m => m.Genre).Where(o => o.MovieTitle.ToLower().Contains(keyIn.ToLower())
                                             || o.Genre.GenreName.ToLower().Contains(keyIn.ToLower())
                                             || o.Director.FName.ToLower().Contains(keyIn.ToLower())
                                             || o.Director.LName.ToLower().Contains(keyIn.ToLower()));
            return searchResults;
        }

        public Movie Update(Movie movieChanges)
        {
            throw new NotImplementedException();
        }
    }
}
