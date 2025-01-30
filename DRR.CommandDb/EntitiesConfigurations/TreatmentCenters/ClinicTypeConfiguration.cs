using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.TreatmentCenters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DRR.CommandDb.EntitiesConfigurations.TreatmentCenters
{
    public class ClinicTypeConfiguration : IEntityTypeConfiguration<ClinicType>
    {
        public void Configure(EntityTypeBuilder<ClinicType> builder)
        {
            builder.HasKey(x => x.Id);

           
        }

    }
}