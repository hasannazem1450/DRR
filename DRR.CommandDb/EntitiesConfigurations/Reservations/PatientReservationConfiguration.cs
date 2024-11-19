﻿using DRR.Domain.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.EntitiesConfigurations.Reservations
{
    class PatientReservationConfiguration : IEntityTypeConfiguration<PatientReservation>
    {
        public void Configure(EntityTypeBuilder<PatientReservation> builder)
        {
            builder.HasKey(x => x.Id);

           
        }

    }
}
