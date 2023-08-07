using AutoMapper;
using Dentistry.DAL.Repositories.ReviewRepository;
using Dentistry.Domain.DTO.Review;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<bool> CreateReviewAsync(ReviewCreationDTO reviewCreationDTO, string userName)
        {
            try
            {
                var review = _mapper.Map<Review>(reviewCreationDTO);
                review.Name = userName;
                review.DateOfReview = DateTime.UtcNow;

                await _reviewRepository.AddAsync(review);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
