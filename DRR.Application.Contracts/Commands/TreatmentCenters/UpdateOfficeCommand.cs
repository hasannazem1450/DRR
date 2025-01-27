using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class UpdateOfficeCommand : Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Geolon { get; set; }
        public double Geolat { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public int OfficeTypeId { get; set; }
    }

    public class UpdateOfficeCommandResponse : CommandResponse
    {
    }
}
