using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
    public class ReadClinicsQuery : Query
    {
    }

    public class ReadClinicsQueryResponse : QueryResponse
    {
        public List<ClinicDto> List { get; set; }
    }
}
