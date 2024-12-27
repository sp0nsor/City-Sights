using CitySights.Core.Models;

namespace CitySights.DataAccess.Repositories
{
    public interface ISightRepository
    {
        Task<Guid> Create(Sight sight);
        Task Delete(Guid id);
        Task<List<Sight>> Get();
        Task<Sight?> GetById(Guid id);
        Task Update(Guid id, Sight updatedSight);
    }
}