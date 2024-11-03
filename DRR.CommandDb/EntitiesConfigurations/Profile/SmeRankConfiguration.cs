using DRR.Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.Profile
{

    public class SmeRankConfiguration : IEntityTypeConfiguration<SmeRank>
    {
        public void Configure(EntityTypeBuilder<SmeRank> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}