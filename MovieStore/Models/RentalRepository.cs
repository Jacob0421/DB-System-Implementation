using Microsoft.EntityFrameworkCore;
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
            string dueDate;
            if (transactionIn.TransactionMovie.IsNewRelease)
            {
                dueDate = DateTime.Parse(transactionIn.TransactionDate).AddDays(4).ToString();
            } else
            {
                dueDate = DateTime.Parse(transactionIn.TransactionDate).AddDays(5).ToString();
            }

            Rental newRental = new Rental()
            {
                RentalTransaction = transactionIn,
                IsLate = false,
                DaysLate = 0,
                Returned = false,
                DueDate = dueDate
            };
            _context.Rentals.Add(newRental);
            return newRental;
        }

        public IEnumerable<Rental> GetOutstandingUserRentals(User userIn)
        {
            return _context.Rentals.Include(r => r.RentalTransaction).Include(r => r.RentalTransaction.Customer).Include(r => r.RentalTransaction.TransactionMovie). Where(r => r.RentalTransaction.Customer == userIn && r.Returned == false);
            //throw new NotImplementedException();
        }
    }
}
