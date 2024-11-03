using DRR.Domain.TreatmentCenters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.TreatmentCenters
{
    class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.City)
            //    .WithMany(x => x.Offices)
            //    .HasForeignKey(x => x.CityId)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.OfficeType)
                .WithMany(x => x.Offices)
                .HasForeignKey(x => x.OfficeTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
