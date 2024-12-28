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

        public async Task Create(Image image)
        {
            var imageEntity = mapper.Map<ImageEntity>(image);

            await context.Images.AddAsync(imageEntity);
            await context.SaveChangesAsync();
        }
    }
}