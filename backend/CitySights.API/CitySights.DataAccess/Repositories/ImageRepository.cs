using AutoMapper;
using CitySights.Core.Models;
using CitySights.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CitySights.DataAccess.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly CitySightDbContext context;
        private readonly IMapper mapper;

        public ImageRepository(CitySightDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Guid> Create(Image image)
        {
            var imageEntity = mapper.Map<ImageEntity>(image);

            await context.Images.AddAsync(imageEntity);
            await context.SaveChangesAsync();

            return imageEntity.Id;
        }

        public async Task<List<Image>> GetBySightId(Guid sightId)
        {
            var imageEntities = await context.Images
                .AsNoTracking()
                .Where(i => i.SightId == sightId)
                .ToListAsync();

            return mapper.Map<List<Image>>(imageEntities);
        }

        public async Task<List<Image>> GetAll()
        {
            var imageEntities = await context.Images
                .AsNoTracking()
                .ToListAsync();

            return mapper.Map<List<Image>>(imageEntities);
        }
    }
}