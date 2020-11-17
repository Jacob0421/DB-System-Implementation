using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IGenreRepository
    {
        public Genre GetGenreByName(string nameIn);
        public Genre AddGenre(string GenreIn);
    }
}
