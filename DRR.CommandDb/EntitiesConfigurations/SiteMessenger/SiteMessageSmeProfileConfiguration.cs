using DRR.Domain.SiteMessenger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.SiteMessenger
{
    public class SiteMessageSmeProfileConfiguration : IEntityTypeConfiguration<SiteMessageReciver>
    {
        public void Configure(EntityTypeBuilder<SiteMessageReciver> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}