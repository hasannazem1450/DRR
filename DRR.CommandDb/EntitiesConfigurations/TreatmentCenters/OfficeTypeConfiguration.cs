using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.TreatmentCenters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.TreatmentCenters
{
    public class OfficeTypeConfiguration : IEntityTypeConfiguration<OfficeType>
    {
        public void Configure(EntityTypeBuilder<OfficeType> builder)
        {
            builder.HasKey(x => x.Id);

            
        }
    }
}
