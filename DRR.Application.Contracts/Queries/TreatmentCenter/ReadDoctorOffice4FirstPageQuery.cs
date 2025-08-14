using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
    public class ReadDoctorOffice4FirstPageQuery : Query
    {
       
    }
    public class ReadDoctorOffice4FirstPageQueryResponse : QueryResponse
    {
        public List<DoctorOfficePackedDto4FirstPage> List { get; set; }
    }
}
