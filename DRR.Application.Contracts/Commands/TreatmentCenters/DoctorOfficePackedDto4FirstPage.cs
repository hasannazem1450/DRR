using DRR.Domain.Customer;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class DoctorOfficePackedDto4FirstPage
    {
        public int Id { get; set; }
        public Guid OfficeId { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string DoctorName { get; set; }
        public string SpecialistName { get; set; }
    }
}
