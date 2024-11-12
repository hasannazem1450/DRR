using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class UpdatePatientCommand :Command
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientFamily { get; set; }
        public string NationalId { get; set; }
        public int BirthNumber { get; set; }
        public string BirthDate { get; set; }
        public int CityId { get; set; }
        public int GlId { get; set; }
        public string PatientPhone { get; set; }
        public string NecessaryPhone { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
    }
    public class UpdatePatientCommandResponse : CommandResponse
    {
    }
}
