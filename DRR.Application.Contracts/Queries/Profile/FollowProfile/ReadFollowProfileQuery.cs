using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Application.Contracts.Commands.Profile.SmeMember;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Profile.FollowProfile
{
    public class ReadFollowProfileQuery : Query
    {
        public int? Id { get; set; }
    }

    public class ReadFollowProfileQueryResponse : QueryResponse
    {
        public ReadFollowProfileQueryResponse()
        {
            List = new List<FollowProfileDto>();
        }
        public List<FollowProfileDto> List { get; set; }
    }
}
