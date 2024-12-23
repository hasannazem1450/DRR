using DRR.Domain.Reserv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Reservations
{
    class VisitCostConfiguration : IEntityTypeConfiguration<VisitCost>
    {
        public void Configure(EntityTypeBuilder<VisitCost> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Doctor)
            //    .WithMany(x => x.VisitCosts)
            //    .HasForeignKey(x => x.DoctorId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.VisitType)
            //    .WithMany(x => x.VisitCosts)
            //    .HasForeignKey(x => x.VisitTypeId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
