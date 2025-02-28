using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
   
    public class ReadDoctorTreatmentCenterOnlineQuery : Query
    {
        public int Id { get; set; }
    }

    public class ReadDoctorTreatmentCenterOnlineQueryResponse : QueryResponse
    {
        public List<DoctorTreatmentCenterDto> List { get; set; }
    }
}
