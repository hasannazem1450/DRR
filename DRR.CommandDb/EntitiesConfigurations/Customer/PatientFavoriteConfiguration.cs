using DRR.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Customer
{
    public class PatientFavoriteConfiguration : IEntityTypeConfiguration<PatientFavorite>
    {
        public void Configure(EntityTypeBuilder<PatientFavorite> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Patient)
            //    .WithMany(x => x.PatientFavorites)
            //    .HasForeignKey(x => x.PatientId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.Doctor)
            //   .WithMany(x => x.PatientFavorites)
            //   .HasForeignKey(x => x.DoctorId)
            //   .OnDelete(DeleteBehavior.NoAction)
            //   .IsRequired (false);

            //builder.HasOne(x => x.Article)
            //   .WithMany(x => x.PatientFavorites)
            //   .HasForeignKey(x => x.ArticleId)
            //   .OnDelete(DeleteBehavior.NoAction)
            //   .IsRequired(false);
        }

    }
}
