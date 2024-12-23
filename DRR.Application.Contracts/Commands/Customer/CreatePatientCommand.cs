using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class CreatePatientCommand : Command
    {
        public string PatientName { get; set; }
        public string PatientFamily { get; set; }
        public string NationalId { get; set; }
        public int BirthNumber { get; set; }
        public string BirthDate { get; set; }
        public int CityId { get; set; }
        public DbGeography Geoloc { get; set; }
        public string PatientPhone { get; set; }
        public string NecessaryPhone { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public int SmeProfileId { get; set; }

    }
    public class CreatePatientCommandResponse : CommandResponse
    {
    }
}
