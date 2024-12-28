using AutoMapper;
using CitySights.Core.Models;
using CitySights.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CitySights.DataAccess.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CitySightDbContext context;
        private readonly IMapper mapper;

        public ReviewRepository(CitySightDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Guid> Create(Review review)
        {
            var reviewEntity = mapper.Map<ReviewEntity>(review);

            await context.Reviews.AddAsync(reviewEntity);
            await context.SaveChangesAsync();

            return reviewEntity.Id;
        }

        public async Task<List<Review>> Get(Guid sightId)
        {
            var reviewEntity = await context.Reviews
                .AsNoTracking()
                .Where(r =>  r.Id == sightId)
                .ToListAsync();

            return mapper.Map<List<Review>>(reviewEntity);
        }

        public async Task Update(
            Guid id,
            string title,
            string reviewText,
            int rating)
        {
            await context.Reviews
                .Where(r => r.Id == id)
                .ExecuteUpdateAsync(r => r
                .SetProperty(r => r.Title, title)
                .SetProperty(r => r.ReviewText, reviewText)
                .SetProperty(r => r.Rating, rating));
        }

        public async Task Delete(Guid id)
        {
            await context.Reviews
                .Where(r => r.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
