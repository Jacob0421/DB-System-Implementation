using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Age_RatingRepository : IAge_RatingRepository
    {
        private readonly AppDbContext _context;

        public Age_RatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public Age_Rating GetAge_RatingByName(string age_ratingIn)
        {
            Age_Rating foundAge_Rating = _context.Age_Ratings.FirstOrDefault(ar => ar.AgeRating == age_ratingIn);

            return foundAge_Rating;
        }
    }
}
