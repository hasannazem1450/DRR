﻿using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class CreateDoctorCommand : Command
    {
        public string DoctorName { get; set; }
        public string DoctorFamily { get; set; }
        public int NationalId { get; set; }
        public int SpecialistId { get; set; }
        public int CodeNezam { get; set; }
        public string DocExperiance { get; set; }
        public string DocInstaLink { get; set; }
        public string Mobile { get; set; }
        public string Desc { get; set; }
        public int SmeProfileId { get; set; }
    }
    public class CreateDoctorCommandResponse : CommandResponse
    {
    }
}