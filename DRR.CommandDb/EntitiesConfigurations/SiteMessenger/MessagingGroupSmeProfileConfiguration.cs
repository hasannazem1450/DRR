using DRR.Domain.SiteMessenger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.SiteMessenger
{
    public class MessagingGroupSmeProfileConfiguration : IEntityTypeConfiguration<MessagingGroupSmeProfile>
    {
        public void Configure(EntityTypeBuilder<MessagingGroupSmeProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SmeProfile)
                .WithMany(x => x.MessagingGroupSmeProfiles)
                .HasForeignKey(x => x.SmeProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.MessagingGroup)
                .WithMany(x => x.MessagingGroupSmeProfiles)
                .HasForeignKey(x => x.MessagingGroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}