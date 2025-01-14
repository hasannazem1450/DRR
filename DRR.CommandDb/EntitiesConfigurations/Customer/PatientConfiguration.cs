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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
           
            builder.HasOne(x => x.City)
                .WithMany(x => x.Patients)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(u => u.PatientName).HasMaxLength(450);
            builder.Property(u => u.PatientFamily).HasMaxLength(450);


            builder.HasIndex(u => u.NationalId).IsUnique();
            builder.Property(u => u.NationalId).HasMaxLength(10);
        }

    }
}
