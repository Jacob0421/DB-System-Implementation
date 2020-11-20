using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class TransactionDetailsRepository : ITransactionDetailsRepository
    {
        private readonly AppDbContext _context;

        public TransactionDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public TransactionDetails AddTransactionDetails(TransactionDetails detailedInputs, Transaction mainTransaction)
        {
            detailedInputs.MainTransaction = mainTransaction;

            _context.TransactionDetails.Add(detailedInputs);

            return detailedInputs;
        }
    }
}
