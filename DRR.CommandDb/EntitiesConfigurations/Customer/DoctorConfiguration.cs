using DRR.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Customer
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Specialist)
                .WithMany(x => x.Doctors)
                .HasForeignKey(x => x.SpecialistId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SmeProfile)
               .WithMany(x => x.Doctors)
               .HasForeignKey(x => x.SmeProfileId)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.DoctorInsurances).WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId);
            builder.HasMany(x => x.DoctorTreatmentCenters).WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId);

            builder.Property(x => x.DoctorName).IsRequired().HasMaxLength(450);
            builder.Property(x => x.DoctorFamily).IsRequired().HasMaxLength(450);
            builder.HasIndex(u => u.NationalId).IsUnique();
            builder.Property(u => u.NationalId).HasMaxLength(10);


        }
    }

}

