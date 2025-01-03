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
    public class CommentReplyConfiguration : IEntityTypeConfiguration<CommentReply>
    {
        public void Configure(EntityTypeBuilder<CommentReply> builder)
        {
            builder.HasKey(x => x.Id);
                        
        }

    }
}
