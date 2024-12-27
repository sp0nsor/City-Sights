using CitySights.Core.Models;

namespace CitySights.DataAccess.Repositories
{
    public interface IReviewRepository
    {
        Task<Guid> Create(Review review);
        Task Delete(Guid id);
        Task<List<Review>> Get(Guid sightId);
        Task Update(Guid id, string title, string reviewText, int rating);
    }
}