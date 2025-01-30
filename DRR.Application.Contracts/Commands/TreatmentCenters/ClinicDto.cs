using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class ClinicDto
    {

        public Guid Id { get; set; }
        public string ClinicName { get; set; }
        public string Address { get; set; }
        public double Geolon { get; set; }
        public double Geolat { get; set; }
        public string Phone { get; set; }
        public string CityName { get; set; }
        public string ProvinceName { get; set; }
        public string SiamCode { get; set; }
        public string Desc { get; set; }
        public string ClinicTypeName { get; set; }
               
    }
}
