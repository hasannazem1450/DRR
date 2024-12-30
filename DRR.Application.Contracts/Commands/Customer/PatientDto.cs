using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.BaseInfo;
using DRR.Domain.Profile;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientFamily { get; set; }
        public string NationalId { get; set; }
        public int BirthNumber { get; set; }
        public string BirthDate { get; set; }
        public virtual City City { get; set; }
        public double Geolat { get; set; }
        public double Geolon { get; set; }
        public string PatientPhone { get; set; }
        public string NecessaryPhone { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public int SmeProfileId { get; set; }
    }
}
