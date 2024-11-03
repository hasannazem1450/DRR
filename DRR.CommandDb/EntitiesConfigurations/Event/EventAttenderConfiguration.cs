using DRR.Domain.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.Event
{

    public class EventAttenderConfiguration : IEntityTypeConfiguration<EventAttender>
    {
        public void Configure(EntityTypeBuilder<EventAttender> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SmeProfile)
                .WithMany(x => x.AttendedEvents)
                .HasForeignKey(x => x.SmeProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.EventInfo)
                .WithMany(x => x.EventAttenders)
                .HasForeignKey(x => x.EventInfoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}