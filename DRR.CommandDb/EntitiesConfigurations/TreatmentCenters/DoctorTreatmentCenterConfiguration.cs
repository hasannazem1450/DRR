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
    public class DoctorTreatmentCenterConfiguration : IEntityTypeConfiguration<DoctorTreatmentCenter>
    {
        public void Configure(EntityTypeBuilder<DoctorTreatmentCenter> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Doctor)
            //    .WithMany(x => x.DoctorTreatmentCenters)
            //    .HasForeignKey(x => x.DoctorId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.Clinic)
            //    .WithMany(x => x.DoctorTreatmentCenters)
            //    .HasForeignKey(x => x.ClinicId)
            //    .OnDelete(DeleteBehavior.NoAction)
            //    .IsRequired (false);

            //builder.HasOne(x => x.Office)
            //    .WithMany(x => x.DoctorTreatmentCenters)
            //    .HasForeignKey(x => x.OfficeId)
            //    .OnDelete(DeleteBehavior.NoAction)
            //    .IsRequired(false);
        }

    }
}
