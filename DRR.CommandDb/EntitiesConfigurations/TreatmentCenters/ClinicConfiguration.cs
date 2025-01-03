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
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Clinics)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ClinicType)
              .WithMany(x => x.Clinics)
              .HasForeignKey(x => x.ClinicTypeId)
              .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
