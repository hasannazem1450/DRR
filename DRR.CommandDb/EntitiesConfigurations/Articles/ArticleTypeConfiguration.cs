using DRR.Domain.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Articles
{
    public class ArticleTypeConfiguration: IEntityTypeConfiguration<ArticleType>
    {
        public void Configure(EntityTypeBuilder<ArticleType> builder)
        {
            builder.HasKey(x => x.Id);

        }

    }
}
