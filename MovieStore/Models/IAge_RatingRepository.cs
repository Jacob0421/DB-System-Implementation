using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IAge_RatingRepository
    {
        Age_Rating GetAge_RatingByName(string age_ratingIn);
    }
}
