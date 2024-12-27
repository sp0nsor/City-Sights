using CitySights.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySights.DataAccess
{
    public class SightEntityConfiguration : IEntityTypeConfiguration<SightEntity>
    {
        public void Configure(EntityTypeBuilder<SightEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired();

            builder.Property(s => s.Description)
                .IsRequired();

            builder.HasOne(i => i.Image)
                .WithOne()
                .HasForeignKey<ImageEntity>(i => i.SightId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.reviews)
                .WithOne()
                .HasForeignKey(r => r.SightId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
