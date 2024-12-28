using CitySights.Core.Models;

namespace CitySights.DataAccess.Repositories
{
    public interface IImageRepository
    {
        Task Create(Image image);
    }
}