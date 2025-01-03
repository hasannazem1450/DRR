using DRR.Domain.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Finance
{
    public class PatientTransactionConfiguration : IEntityTypeConfiguration<PatientTransaction>
    {
        public void Configure(EntityTypeBuilder<PatientTransaction> builder)
        {
            builder.HasKey(x => x.Id);

           
        }

    }
}
