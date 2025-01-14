using DRR.Domain.Specialists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.Infrastructure.Annotations;
namespace DRR.CommandDb.EntitiesConfigurations.Specialists
{
    public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(u => u.Name).IsUnique();
            builder.HasIndex(u => u.Maxa).IsUnique();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(450);
            builder.Property(x => x.Maxa).IsRequired().HasMaxLength(20);

        }

    }
}
