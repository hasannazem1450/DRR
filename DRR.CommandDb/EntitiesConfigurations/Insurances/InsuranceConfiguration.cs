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
    public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.InsuranceType)
                   .WithMany(x => x.Insurances)
                   .HasForeignKey(x => x.InsuranceTypeId)
                   .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
