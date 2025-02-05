using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class UpdateDoctorCommand : Command
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorFamily { get; set; }
        public string NationalId { get; set; }
        public int CodeNezam { get; set; }
        public int SpecialistId { get; set; }
        public string DocExperiance { get; set; }
        public string DocInstaLink { get; set; }
        public string Mobile { get; set; }
        public string Desc { get; set; }
        //public bool? Gender { get; set; }
    }
    public class UpdateDoctorCommandResponse : CommandResponse
    {

    }
}
