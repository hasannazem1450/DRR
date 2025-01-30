using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
    public class ReadOfficeTypesQuery : Query
    {
    }

    public class ReadOfficeTypesQueryResponse : QueryResponse
    {
        public List<OfficeTypeDto> List { get; set; }
    }
}

