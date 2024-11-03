using DRR.Domain.Profile.Follow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DRR.CommandDb.EntitiesConfigurations.Profile.Follow
{
    public class FollowProfileConfiguration : IEntityTypeConfiguration<FollowProfile>
    {
        public void Configure(EntityTypeBuilder<FollowProfile> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
