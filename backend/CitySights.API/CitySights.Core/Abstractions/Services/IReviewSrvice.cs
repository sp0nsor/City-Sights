using CitySights.Core.Models;
using CSharpFunctionalExtensions;

namespace CitySights.Application.Services
{
    public interface IReviewSrvice
    {
        Task<Result<Guid>> CreateReview(Review review);
        Task<Result> DeleteReview(Guid id);
        Task<Result<List<Review>>> GetReviews(Guid sightId);
        Task<Result> UpdateReview(Guid id, string title, string reviewText, int rating);
    }
}