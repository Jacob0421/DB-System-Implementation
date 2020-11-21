using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        public TransactionRepository (AppDbContext context)
        {
            _context = context;
        }

        public Transaction CreateTransaction(Movie movieIn, User userIn, bool IsRental)
        {
            Transaction newTransaction = new Transaction()
            {
                TransactionDate = DateTime.Today.ToString(),
                TransactionMovie = movieIn,
                Customer = userIn,
                IsRental = IsRental
            };
            _context.Transactions.Add(newTransaction);
            _context.SaveChangesAsync();
            return newTransaction;
        }

        public IEnumerable<Transaction> GetUserTransactions(User userIn)
        {
            return _context.Transactions.Where(t => t.Customer == userIn);
        }
    }
}
