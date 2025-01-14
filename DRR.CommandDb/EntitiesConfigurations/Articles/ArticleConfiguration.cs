using DRR.Domain.Articles;
using DRR.Domain.Profile;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DRR.CommandDb.EntitiesConfigurations.Articles
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SmeProfile)
               .WithMany(x => x.Articles)
               .HasForeignKey(x => x.SmeProfileId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(u => u.Title).IsUnique();
            builder.Property(u => u.Title).HasMaxLength(450);
            builder.Property(x => x.Authors).HasMaxLength(450);
        }
    }

}
