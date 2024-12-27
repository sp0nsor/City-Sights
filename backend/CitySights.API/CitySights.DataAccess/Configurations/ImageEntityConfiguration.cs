using CitySights.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySights.DataAccess.Configurations
{
    public class ImageEntityConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.FileName)
                .IsRequired();

            builder.HasOne<SightEntity>()
                .WithOne(s => s.Image)
                .HasForeignKey<ImageEntity>(i => i.SightId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
