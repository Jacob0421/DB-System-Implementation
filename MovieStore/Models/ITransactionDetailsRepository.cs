using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface ITransactionDetailsRepository
    {
        TransactionDetails AddTransactionDetails(TransactionDetails detailedInputs, Transaction mainTransaction);
    }
}
