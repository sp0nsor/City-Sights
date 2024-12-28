using CitySights.Core.Models;
using CSharpFunctionalExtensions;

namespace CitySights.Application.Services
{
    public interface IReviewSrvice
    {
        Task<Result<Guid>> CreateReview(Review review);
    }
}