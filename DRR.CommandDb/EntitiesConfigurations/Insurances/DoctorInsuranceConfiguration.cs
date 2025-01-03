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
    public class DoctorInsuranceConfiguration : IEntityTypeConfiguration<DoctorInsurance>
    {
        public void Configure(EntityTypeBuilder<DoctorInsurance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.DoctorInsurances)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Insurance)
                .WithMany(x => x.DoctorInsurances)
                .HasForeignKey(x => x.InsuranceId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

        }

    }
}
