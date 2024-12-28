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

        public async Task<Result<List<Review>>> GetReviews(Guid sightId)
        {
            try
            {
                var reviews = await reviewRepository.Get(sightId);

                return Result.Success(reviews);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<Review>>(ex.Message);
            }
        }

        public async Task<Result> UpdateReview(Guid id, string title, string reviewText, int rating)
        {
            try
            {
                await reviewRepository.Update(id, title, reviewText, rating);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteReview(Guid id)
        {
            try
            {
                await reviewRepository.Delete(id);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
