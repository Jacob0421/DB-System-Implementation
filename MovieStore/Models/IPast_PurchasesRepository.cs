using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IPast_PurchasesRepository
    {
        Past_Purchases GetGenres(Past_Purchases past_PurchaseIn);
    }
}
