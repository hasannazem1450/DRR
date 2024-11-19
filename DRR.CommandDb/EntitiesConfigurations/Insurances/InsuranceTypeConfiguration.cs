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
    class InsuranceTypeConfiguration : IEntityTypeConfiguration<InsuranceType>
    {
        public void Configure(EntityTypeBuilder<InsuranceType> builder)
        {
            builder.HasKey(x => x.Id);


        }

    }
}
