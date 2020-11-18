﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Past_PurchasesRepository : IPast_PurchasesRepository
    {
        private readonly AppDbContext _context;

        public Past_PurchasesRepository (AppDbContext context)
        {
            _context = context;
        }

        public Past_Purchases GetUserTransactions(Past_Purchases past_PurchaseIn)

        {
            IEnumerable<Transaction> userTransactions = _context.Transactions.Where(t => t.Customer == past_PurchaseIn.Customer);

             String GetMovieName(IEnumerable<Transaction>)
            {
   
                return Transaction.Movie(t => t.Movie == Movie).Name;
            }

            return past_PurchaseIn;
        }
    }
}
