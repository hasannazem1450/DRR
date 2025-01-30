using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class UpdateClinicCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Geolon { get; set; }
        public double Geolat { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string SiamCode { get; set; }
        public string Desc { get; set; }
        public int ClinicTypeId { get; set; }
    }

    public class UpdateClinicCommandResponse : CommandResponse
    {
    }
}
