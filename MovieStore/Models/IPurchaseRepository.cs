﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IPurchaseRepository
    {
        Purchase AddPurchase(Transaction transactionIn);
        Purchase GetPurchaseByTransaction(Transaction transactionIn);
    }
}
