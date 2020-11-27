using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    class PurchaseRepository: IPurchaseRepository
    {

        private readonly AppDbContext _context;

        public PurchaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public Purchase AddPurchase(Transaction transactionIn)
        {
            Purchase newPurchase = new Purchase()
            {
                PurchaseTransaction = transactionIn
            };

            _context.Purchases.Add(newPurchase);
            return newPurchase;
        }

        public Purchase GetPurchaseByTransaction(Transaction transactionIn)
        {
            return _context.Purchases.Include(p => p.PurchaseTransaction).Include(p => p.PurchaseTransaction.TransactionMovie).Include(p => p.PurchaseTransaction.Customer).FirstOrDefault(p => p.PurchaseTransaction == transactionIn);
        }
    }
}
