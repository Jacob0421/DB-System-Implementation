using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IRentalRepository
    {
        Rental AddRental(Transaction transactionIn);
        IEnumerable<Rental> GetOutstandingUserRentals(User userIn);
        Rental GetRentalById(int rentalIdIn);
    }
}
