using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IReviewRepository
    {
        public Review Add(Review newReview);
        IEnumerable<Review> GetAllReviews();
    }
}
