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
    class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
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


        }
    }

}

