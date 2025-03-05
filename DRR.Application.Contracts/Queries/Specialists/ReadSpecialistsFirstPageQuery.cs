using DRR.Application.Contracts.Commands.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Specialists
{
    public class ReadSpecialistsFirstPageQuery : Query
    {
       
    }
    public class ReadSpecialistsFirstPageQueryResponse : QueryResponse
    {
        public ReadSpecialistsFirstPageQueryResponse()
        {
            List = new List<SpecialistDto>();
        }
        public List<SpecialistDto> List { get; set; }
    }
}