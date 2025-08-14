using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
    public class ReadDoctorTreatmentCenters4FirstPageQuery : Query
    {
       
    }
    public class ReadDoctorTreatmentCenters4FirstPageQueryResponse : QueryResponse
    {
        public List<DoctorTreatmentCenterPackedDto4FirstPage> List { get; set; }
    }
}
