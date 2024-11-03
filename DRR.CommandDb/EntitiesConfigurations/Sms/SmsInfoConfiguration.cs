using DRR.Domain.Sms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.Sms;

public class SmsInfoConfiguration : IEntityTypeConfiguration<SmsInfo>
{
    public void Configure(EntityTypeBuilder<SmsInfo> builder)
    {
    }
}