using DRR.Domain.SiteMessenger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.SiteMessenger
{
    public class SiteMessageReciverConfiguration : IEntityTypeConfiguration<SiteMessageReciver>
    {
        public void Configure(EntityTypeBuilder<SiteMessageReciver> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SiteMessage)
                .WithMany(x => x.SiteMessageRecivers)
                .HasForeignKey(x => x.SiteMessageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SmeProfile)
                .WithMany(x => x.SiteMessageRecivers)
                .HasForeignKey(x => x.SmeProfileId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne(x => x.MessagingGroup)
                .WithMany(x => x.SiteMessageRecivers)
                .HasForeignKey(x => x.MessagingGroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}