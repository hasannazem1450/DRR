using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.News
{
    public class EventConfiguration : IEntityTypeConfiguration<Domain.News.Ads>
    {
        public void Configure(EntityTypeBuilder<Domain.News.Ads> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SmeProfile)
                .WithMany(x => x.Ads)
                .HasForeignKey(x => x.SmeProfileId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
