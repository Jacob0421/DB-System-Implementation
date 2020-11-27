using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Transaction> GetTransactionsByGenre(Genre genreIn)
        {
            return _context.Transactions.Include(t => t.TransactionMovie).Include(t => t.TransactionMovie.Genre).Where(t => t.TransactionMovie.Genre == genreIn);
        }

        public IEnumerable<Transaction> GetUserTransactions(User userIn)
        {
            return _context.Transactions.Include(t => t.Customer).Include(t => t.TransactionMovie).Include(t => t.TransactionMovie.Genre).Where(t => t.Customer == userIn);
        }

        public IEnumerable<Transaction> GetRevenueReportByGenre(Genre genreIn, DateTime startDate, DateTime endDate)
        {
            return _context.Transactions.Include(t => t.TransactionMovie).Where(t => t.TransactionMovie.Genre == genreIn && DateTime.Parse(t.TransactionDate) > startDate && DateTime.Parse(t.TransactionDate) < endDate);
        }

        public IEnumerable<Transaction> GetRevenueReportByTitle(Movie movieIn)
        {
            return _context.Transactions.Include(t => t.TransactionMovie).Where(t => t.TransactionMovie == movieIn);
        }
    }
}
