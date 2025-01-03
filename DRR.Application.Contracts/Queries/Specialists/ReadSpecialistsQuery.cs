using DRR.Application.Contracts.Commands.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Specialists
{
    public class ReadSpecialistsQuery : Query
    {
       
    }
    public class ReadSpecialistsQueryResponse : QueryResponse
    {
        public ReadSpecialistsQueryResponse()
        {
            List = new List<SpecialistDto>();
        }
        public List<SpecialistDto> List { get; set; }
    }
}