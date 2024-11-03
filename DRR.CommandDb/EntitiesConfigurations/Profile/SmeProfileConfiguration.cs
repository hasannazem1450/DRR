using DRR.Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.Profile
{

    public class SmeProfileConfiguration : IEntityTypeConfiguration<SmeProfile>
    {
        public void Configure(EntityTypeBuilder<SmeProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.City)
                .WithMany(x => x.SmeProfiles)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SmeRank)
                .WithMany(x => x.SmeProfiles)
                .HasForeignKey(x => x.SmeRankId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

          
        }
    }
}