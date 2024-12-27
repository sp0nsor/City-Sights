using CitySights.Core.Models;

namespace CitySights.DataAccess.Repositories
{
    public interface IImageRepository
    {
        Task<Guid> Create(Image image);
        Task<List<Image>> GetAll();
        Task<List<Image>> GetBySightId(Guid sightId);
    }
}