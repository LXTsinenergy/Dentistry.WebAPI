using Dentistry.Domain.DTO.Review;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.ReviewService
{
    public interface IReviewService
    {
        Task<bool> CreateReviewAsync(ReviewCreationDTO reviewCreationDTO, string userName);
    }
}
