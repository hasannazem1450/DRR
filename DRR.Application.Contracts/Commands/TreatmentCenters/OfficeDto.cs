using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.BaseInfo;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class OfficeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Geolon { get; set; }
        public double Geolat { get; set; }
        public string CityName { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string OfficeTypeName { get; set; }
        public City City { get; set; }
    }
}
