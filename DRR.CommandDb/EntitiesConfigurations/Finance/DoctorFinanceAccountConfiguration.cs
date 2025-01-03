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
    public class DoctorFinanceAccountConfiguration: IEntityTypeConfiguration<DoctorFinanceAccount>
    {
        public void Configure(EntityTypeBuilder<DoctorFinanceAccount> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Doctor)
            //    .WithMany(x => x.DoctorFinanceAccounts)
            //    .HasForeignKey(x => x.DoctorId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
