using DRR.Domain.FileManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.FileManagment
{

    public class DRRFileConfiguration : IEntityTypeConfiguration<DRRFile>
    {
        public void Configure(EntityTypeBuilder<DRRFile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OriginalName).HasMaxLength(250);
            builder.Property(x => x.Extension).HasMaxLength(50);
            builder.Property(x => x.EntityName).HasMaxLength(50);
            builder.Property(x => x.SizeKb).IsRequired(false);
            builder.Property(x => x.FullPath).IsRequired(false);
        }
    }
}