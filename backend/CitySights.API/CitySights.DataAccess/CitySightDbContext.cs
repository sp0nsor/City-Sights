using CitySights.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CitySights.DataAccess
{
    public class CitySightDbContext : DbContext 
    {
        public CitySightDbContext(DbContextOptions<CitySightDbContext> opetions) : base(opetions) { }

        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<SightEntity> Sights { get; set; }
    }
}
