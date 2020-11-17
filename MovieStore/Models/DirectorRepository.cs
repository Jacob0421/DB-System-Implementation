using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly AppDbContext _context;

        public DirectorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Director AddDirector(string fNameIn, string lNameIn)
        {
            Director newDirector = new Director()
            {
                FName = fNameIn,
                LName = lNameIn
            };
            _context.Directors.Add(newDirector);
            return newDirector;
        }

        public Director GetDirectorByName(string fNameIn, string lNameIn)
        {
            Director foundDirector = _context.Directors.FirstOrDefault(d => d.FName.ToLower() == fNameIn.ToLower() && d.LName.ToLower() == lNameIn);
            return foundDirector;
        }
    }
}
