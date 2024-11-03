using DRR.Domain.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Reservations
{
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Doctor)
            //    .WithMany(x => x.Reservations)
            //    .HasForeignKey(x => x.DoctorId)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.VisitType)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.VisitTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.DoctorTreatmentCenter)
            //    .WithMany(x => x.Reservations)
            //    .HasForeignKey(x => x.DoctorTreatmentCenterId)
            //    .OnDelete(DeleteBehavior.NoAction)
            //    .IsRequired (false);

        }

    }
}
