using DRR.Application.Contracts.Commands.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Specialists
{
    public class ReadCategoryQuery : Query
    {
        public int Id { get; set; }
    }
    public class ReadCategoryQueryResponse : QueryResponse
    {
        public SpecialistCategoryDto Data { get; set; }
    }
}
