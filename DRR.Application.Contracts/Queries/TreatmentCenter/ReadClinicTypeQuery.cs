using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
    public class ReadClinicTypeQuery : Query
    {
        public int Id { get; set; }
    }

    public class ReadClinicTypeQueryResponse : QueryResponse
    {
        public ClinicTypeDto Data { get; set; }
    }
}

