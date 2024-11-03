using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Queries.SystemMessages;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.RoleManager
{
    public class ReadRoleQuery : Query
    {

    }

    public class ReadRoleQueryResponse : QueryResponse
    {
        public ReadRoleQueryResponse()
        {
            List = new List<RoleDto>();
        }
        public List<RoleDto> List { get; set; }
    }
}
