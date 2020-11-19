using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class RentalRepository : IRentalRepository
    {
        private readonly AppDbContext _context;

        public RentalRepository (AppDbContext context)
        {
            _context = context;
        }

        public Rental AddRental(Transaction transactionIn)
        {
            Rental newRental = new Rental()
            {
                RentalTransaction = transactionIn,
                IsLate = false,
                DaysLate = 0                
            };
            _context.Rentals.Add(newRental);
            return newRental;
        }
    }
}
