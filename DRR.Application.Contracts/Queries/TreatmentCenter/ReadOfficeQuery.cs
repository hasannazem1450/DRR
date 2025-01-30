using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
    public class ReadOfficeQuery : Query
    {
        public int Id { get; set; }
    }

    public class ReadOfficeQueryResponse : QueryResponse
    {
        public OfficeDto Data { get; set; }
    }
}

