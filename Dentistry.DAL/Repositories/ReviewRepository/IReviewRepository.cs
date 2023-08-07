using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.ReviewRepository
{
    public interface IReviewRepository
    {
        public Task CreateAsync(Review review);
    }
}
