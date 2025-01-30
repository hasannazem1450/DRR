using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
    public class ReadDoctorTreatmentCentersQuery : Query
    {
    }

    public class ReadDoctorTreatmentCentersQueryResponse : QueryResponse
    {
        public List<DoctorTreatmentCenterDto> List { get; set; }
    }
}
