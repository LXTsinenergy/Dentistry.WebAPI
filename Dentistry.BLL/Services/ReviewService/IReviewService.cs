using Dentistry.Domain.DTO.Review;

namespace Dentistry.BLL.Services.ReviewService
{
    public interface IReviewService
    {
        Task<bool> CreateReviewAsync(ReviewCreationDTO reviewCreationDTO, string userName);
    }
}
