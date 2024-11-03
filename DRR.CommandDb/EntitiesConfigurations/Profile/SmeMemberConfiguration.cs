using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.Profile
{
    public class SmeMemberConfiguration : IEntityTypeConfiguration<SmeMember>
    {
        public void Configure(EntityTypeBuilder<SmeMember> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SmeProfile)
                .WithMany(x => x.SmeMembers)
                .HasForeignKey(x => x.SmeProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Position)
                .WithMany(x => x.SmeMembers)
                .HasForeignKey(x => x.PositionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
