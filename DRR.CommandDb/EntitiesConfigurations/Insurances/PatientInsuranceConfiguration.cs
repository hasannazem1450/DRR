using DRR.Domain.Insurances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Insurances
{
    class PatientInsuranceConfiguration : IEntityTypeConfiguration<PatientInsurance>
    {
        public void Configure(EntityTypeBuilder<PatientInsurance> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Patient)
            //    .WithMany(x => x.PatientInsurances)
            //    .HasForeignKey(x => x.PatientId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.InsuranceType)
            //   .WithMany(x => x.PatientInsurances)
            //   .HasForeignKey(x => x.InsuranceTypeId)
            //   .OnDelete(DeleteBehavior.NoAction)
            //   .IsRequired(false);

            //builder.HasOne(x => x.Insurance)
            //   .WithMany(x => x.PatientInsurances)
            //   .HasForeignKey(x => x.InsuranceId)
            //   .OnDelete(DeleteBehavior.NoAction)
            //   .IsRequired(false);
        }

    }
}
