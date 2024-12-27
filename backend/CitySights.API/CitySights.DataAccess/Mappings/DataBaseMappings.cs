using AutoMapper;
using CitySights.Core.Models;
using CitySights.DataAccess.Entities;

namespace CitySights.DataAccess.Mappings
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings()
        {
            CreateMap<Image, ImageEntity>();
            CreateMap<Review, ReviewEntity>();
            CreateMap<Sight, SightEntity>();
        }
    }
}
