using DRR.Domain.SiteMessenger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.SiteMessenger
{
    public class MessagingGroupConfiguration : IEntityTypeConfiguration<MessagingGroup>
    {
        public void Configure(EntityTypeBuilder<MessagingGroup> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}