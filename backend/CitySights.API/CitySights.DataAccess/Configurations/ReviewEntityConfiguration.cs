using CitySights.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CitySights.DataAccess.Configurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .IsRequired();

            builder.Property(r => r.ReviewText)
                .IsRequired();

            builder.Property(r => r.Rating)
                .IsRequired();

            builder.HasOne(r => r.Sight)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.SightId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
