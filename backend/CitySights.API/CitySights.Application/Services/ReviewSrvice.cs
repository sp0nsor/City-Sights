using CitySights.Core.Models;
using CitySights.DataAccess.Repositories;
using CSharpFunctionalExtensions;

namespace CitySights.Application.Services
{
    public class ReviewSrvice : IReviewSrvice
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewSrvice(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task<Result<Guid>> CreateReview(Review review)
        {
            try
            {
                var reviewId = await reviewRepository.Create(review);

                return Result.Success(reviewId);
            }
            catch (Exception ex)
            {
                return Result.Failure<Guid>(ex.Message);
            }
        }
    }
}
