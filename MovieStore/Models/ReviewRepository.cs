using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;
        public  ReviewRepository(AppDbContext context) {
            _context = context;
        }
        public Review Add(Review ReviewIn)
        {
            ReviewIn.ReviewDate = DateTime.Today.ToShortDateString();
            _context.Reviews.Add(ReviewIn);
            _context.SaveChanges();
            return ReviewIn;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _context.Reviews;
        }
    }
}
