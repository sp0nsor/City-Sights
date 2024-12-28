using CitySights.Core.Models;
using CitySights.DataAccess.Repositories;
using CSharpFunctionalExtensions;

namespace CitySights.Application.Services
{
    public class SightService : ISightService
    {
        private readonly ISightRepository sightRepository;

        public SightService(ISightRepository sightRepository)
        {
            this.sightRepository = sightRepository;
        }

        public async Task<Result<Guid>> CreateSight(Sight sight)
        {
            try
            {
                var id = await sightRepository.Create(sight);

                return Result.Success(id);
            }
            catch (Exception ex)
            {
                return Result.Failure<Guid>(ex.Message);
            }
        }

        public async Task<Result<List<Sight>>> GetSights()
        {
            try
            {
                var sights = await sightRepository.Get();

                return Result.Success(sights);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<Sight>>(ex.Message);
            }
        }

        public async Task<Result> UpdateSight(Guid id, string name, string description)
        {
            try
            {
                await sightRepository.Update(id, name, description);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteSight(Guid id)
        {
            try
            {
                await sightRepository.Delete(id);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
