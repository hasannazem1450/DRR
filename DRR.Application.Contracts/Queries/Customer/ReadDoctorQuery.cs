using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.News;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadDoctorQuery : Query
    {
        public int SmeProfileId {  get; set; }
    }

    public class ReadDoctorQueryResponse : QueryResponse
    {
        public ReadDoctorQueryResponse()
        {
            List = new List<DoctorDto>();
        }
        public List<DoctorDto> List { get; set; }
    }
}
