using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }
    }
}
