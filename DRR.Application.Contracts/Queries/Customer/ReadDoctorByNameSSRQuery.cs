using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{

    public class ReadDoctorByNameSSRQuery : Query
    {
        public String SSRName { get; set; }
    }

    public class ReadDoctorByNameSSRQueryResponse : QueryResponse
    {
        public DoctorDto Data { get; set; }
    }

}
