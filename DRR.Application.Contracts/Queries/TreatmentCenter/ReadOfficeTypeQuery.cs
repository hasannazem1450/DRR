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
    public class ReadOfficeTypeQuery : Query
    {
        public int Id { get; set; }
    }

    public class ReadOfficeTypeQueryResponse : QueryResponse
    {
        public OfficeType Data { get; set; }
    }
}

