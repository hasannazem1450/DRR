using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Profile.SmeProfile
{
    public class ReadPreSmeProfileQuery : Query
    {

    }

    public class ReadPreSmeProfileQueryResponse : QueryResponse
    {
        public List<PreSmeProfileDto> List { get; set; }
    }
}
