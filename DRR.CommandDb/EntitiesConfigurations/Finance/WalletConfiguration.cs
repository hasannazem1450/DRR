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
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.SmeProfile)
            //    .WithMany(x => x.Wallets)
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }



    }
}
