using DRR.Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.Profile
{

    public class SmeRaterConfiguration : IEntityTypeConfiguration<SmeRater>
    {
        public void Configure(EntityTypeBuilder<SmeRater> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}