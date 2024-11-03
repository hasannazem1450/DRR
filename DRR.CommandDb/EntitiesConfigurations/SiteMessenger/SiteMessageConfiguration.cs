using DRR.Domain.SiteMessenger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.SiteMessenger
{
    public class SiteMessageConfiguration : IEntityTypeConfiguration<SiteMessage>
    {
        public void Configure(EntityTypeBuilder<SiteMessage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SenderUser)
                .WithMany(x => x.SiteMessages)
                .HasForeignKey(x => x.SenderUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}