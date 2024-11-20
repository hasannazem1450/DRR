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
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Doctor)
                   .WithMany(x => x.Comments)
                   .HasForeignKey(x => x.DoctorId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.SmeProfile)
                   .WithMany(x => x.Comments)
                   .HasForeignKey(x => x.SmeProfileId)
                   .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
