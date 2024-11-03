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
    class PatientReservationConfiguration : IEntityTypeConfiguration<PatientReservation>
    {
        public void Configure(EntityTypeBuilder<PatientReservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.PatientReservations)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.Reservation)
            //    .WithMany(x => x.PatientReservations)
            //    .HasForeignKey(x => x.ReservationId)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.VisitCost)
                .WithMany(x => x.PatientReservations)
                .HasForeignKey(x => x.VisitCostId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.DiscountCode)
            //    .WithMany(x => x.PatientReservations)
            //    .HasForeignKey(x => x.DiscountCodeId)
            //    .OnDelete(DeleteBehavior.NoAction)
            //    .IsRequired (false);
        }

    }
}
