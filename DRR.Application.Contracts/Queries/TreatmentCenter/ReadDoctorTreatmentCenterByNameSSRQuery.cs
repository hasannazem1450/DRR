using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
    public class ReadDoctorTreatmentCenterByNameSSRQuery :Query
    {
        public String SSRName { get; set; }
    }

    public class ReadDoctorTreatmentCenterByNameSSRQueryResponse : QueryResponse
    {
        public DoctorTreatmentCenterSSRDto Data { get; set; }
    }
}
