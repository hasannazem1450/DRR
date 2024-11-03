using DRR.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Comments
{
    class ArticleCommentConfiguration : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.SmeProfile)
            //    .WithMany(x => x.ArticleComments)
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder
            //  .HasOne(x => x.Article)
            //  .WithMany(x => x.ArticleComments)
            //  .HasForeignKey(x => x.ArticleId)
            //  .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
