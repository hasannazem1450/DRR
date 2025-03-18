using DRR.Application.Contracts.Commands.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Specialists
{
    public class ReadCategorysQuery : Query
    {
    }
    public class ReadCategorysQueryResponse : QueryResponse
    {

        public ReadCategorysQueryResponse()
        {
            List = new List<SpecialistCategoryDto>();
        }
        public List<SpecialistCategoryDto> List { get; set; }
    }
}
