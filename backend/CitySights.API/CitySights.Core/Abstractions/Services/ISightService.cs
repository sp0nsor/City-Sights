using CitySights.Core.Models;
using CSharpFunctionalExtensions;

namespace CitySights.Application.Services
{
    public interface ISightService
    {
        Task<Result<Guid>> CreateSight(Sight sight);
        Task<Result> DeleteSight(Guid id);
        Task<Result<List<Sight>>> GetSights();
        Task<Result> UpdateSight(Sight sight);
    }
}