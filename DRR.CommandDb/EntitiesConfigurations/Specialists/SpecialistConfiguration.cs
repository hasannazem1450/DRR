using DRR.Domain.Specialists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DRR.CommandDb.EntitiesConfigurations.Specialists
{
    public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            builder.HasKey(x => x.Id);

          
        }

    }
}
