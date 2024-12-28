using AutoMapper;
using CitySights.Core.Models;
using CitySights.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CitySights.DataAccess.Repositories
{
    public class SightRepository : ISightRepository
    {
        private readonly CitySightDbContext context;
        private readonly IMapper mapper;

        public SightRepository(CitySightDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Guid> Create(Sight sight)
        {
            var sightEntity = mapper.Map<SightEntity>(sight);

            await context.Sights.AddAsync(sightEntity);
            await context.SaveChangesAsync();

            return sightEntity.Id;
        }

        public async Task<List<Sight>> Get()
        {
            var sightEntities = await context.Sights
                .AsNoTracking()
                .ToListAsync();

            return mapper.Map<List<Sight>>(sightEntities);
        }

        public async Task Update(Sight updatedSight)
        {
            var sightEntity = await context.Sights.FindAsync(updatedSight.Id);
            if (sightEntity == null)
            {
                throw new KeyNotFoundException("Sight not found");
            }

            var imageEntity = mapper.Map<ImageEntity>(updatedSight.Image);

            sightEntity.Name = updatedSight.Name;
            sightEntity.Description = updatedSight.Description;
            sightEntity.Image = imageEntity;

            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var sightEntity = await context.Sights.FindAsync(id);
            if (sightEntity == null)
            {
                throw new KeyNotFoundException("Sight not found");
            }

            context.Sights.Remove(sightEntity);
            await context.SaveChangesAsync();
        }
    }
}
