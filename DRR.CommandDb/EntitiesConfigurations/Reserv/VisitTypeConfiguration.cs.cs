﻿using DRR.Domain.Reserv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Reservations
{
    public class VisitTypeConfiguration :IEntityTypeConfiguration<VisitType>
    {
        public void Configure(EntityTypeBuilder<VisitType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(u => u.VisitTypeName).IsUnique();
            builder.Property(x => x.VisitTypeName).IsRequired().HasMaxLength(450);
        }

    }
}
