using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{

    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public Genre AddGenre(string GenreIn)
        {
            Genre newGenre = new Genre()
            {
                GenreName = GenreIn,
            };
            _context.Genre.Add(newGenre);
            _context.SaveChanges();
            return newGenre;
        }

        public Genre GetGenreByName(string nameIn)
        {
            Genre foundGenre = _context.Genre.FirstOrDefault(g => g.GenreName == nameIn);

            return foundGenre;
        }
    }
}
