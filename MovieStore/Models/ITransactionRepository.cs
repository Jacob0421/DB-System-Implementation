using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface ITransactionRepository
    {
        Transaction CreateTransaction(Movie movieIn, User userIn, bool IsRental);
        IEnumerable<Transaction> GetUserTransactions(User userIn);
    }
}
