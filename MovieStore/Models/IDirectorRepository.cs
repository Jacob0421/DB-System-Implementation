using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IDirectorRepository
    {
        public Director GetDirectorByName(string fNameIn, string lNameIn);
        public Director AddDirector(string fNameIn, string lNameIn);
    }
}
