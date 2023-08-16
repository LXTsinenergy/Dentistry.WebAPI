using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IApplicationDbContext _context;

        public ReviewRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Review review, CancellationToken cancellationToken)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
